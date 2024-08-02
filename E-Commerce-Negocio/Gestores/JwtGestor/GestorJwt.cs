using E_Commerce_Comun.Entidades;
using E_Commerce_Comun.Sealed;
using E_Commerce_Negocio.Config;
using E_Commerce_Negocio.DTOs.AuthDTOs;
using E_Commerce_Negocio.Gestores.EncoderGestor;
using E_Commerce_Negocio.Gestores.UsuarioIdentityGestor;
using E_Commerce_Negocio.Repositorios.RefreshTokenRepo;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.JwtGestor
{
    public class GestorJwt : IGestorJwt
    {
        private readonly JwtConfig _jwtConfig;
        private readonly IRepositorioRefreshToken _refTokRepo;
        private readonly IGestorEncoder _encoder;
        private readonly TokenValidationParameters _tokenVP;
        private readonly IGestorUsuarioIdentity _userIdG;

        public GestorJwt(
            IOptions<JwtConfig> jwtConfig,
            IRepositorioRefreshToken refTokRepo,
            IGestorEncoder encoder,
            TokenValidationParameters tokenVP,
            IGestorUsuarioIdentity userIdG)
        {
            _jwtConfig = jwtConfig.Value;
            _refTokRepo = refTokRepo;
            _encoder = encoder;
            _tokenVP = tokenVP;
            _userIdG = userIdG;
        }

        public async Task<AuthResultDto> GenerarTokenAsync(UsuarioIdentity user)
        {
            var response = new AuthResultDto();
            
            try
			{
                var jwtTokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new ClaimsIdentity(new[]
                    {
                        new Claim("Id", user.Id),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                    })),
                    Expires = DateTime.UtcNow.Add(_jwtConfig.ExpiryTime),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var token = jwtTokenHandler.CreateToken(tokenDescriptor);

                var jwtToken = jwtTokenHandler.WriteToken(token);

                var refreshTokenEntity = new RefreshToken()
                {
                    IdUser = user.Id,
                    Token = _encoder.GenerarStringAleatorio(23),
                    IdJwt = token.Id,
                    Used = false,
                    Revoked = false,
                    AddedDate = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddMonths(6)
                };

                var refreshToken = await _refTokRepo.Crear(refreshTokenEntity);

                if(refreshToken == null)
                {
                    return null;
                }

                response.AccessToken = jwtToken;
                response.RefreshToken = refreshToken.Token;
                response.Result = true;

                return response;
                
            }
			catch (Exception exc)
			{

				throw exc;
			}
        }

        public async Task<AuthResultDto> VerificarYGenerarTokenAsync(TokenRequestDto request)
        {
            var response = new AuthResultDto();
            var jwtHandler = new JwtSecurityTokenHandler();

            try
            {
                if(request == null)
                {
                    response.AccessToken = string.Empty;
                    response.RefreshToken = string.Empty;
                    response.Result = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El cuerpo de la solicitud no puede ser null.", MessageClass.Danger, "NullRequest"));

                    return response;
                }

                _tokenVP.ValidateLifetime = false;

                var tokenHandled = jwtHandler.ValidateToken(request.AccessToken, _tokenVP, out var validatedToken);

                if(validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if(result == false || tokenHandled == null)
                    {
                        response.AccessToken = string.Empty;
                        response.RefreshToken = string.Empty;
                        response.Result = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Mensajes.Add(new Mensaje("Bad request.", MessageClass.Danger, "BadRequest"));
                        response.Mensajes.Add(new Mensaje("Tokens inválidos.", MessageClass.Danger, "BadRequest"));

                        return response;
                    }

                    var utcExpiryDate = long.Parse(tokenHandled.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp).Value);

                    var expiryDate = DateTimeOffset.FromUnixTimeSeconds(utcExpiryDate).UtcDateTime;

                    if(expiryDate < DateTime.UtcNow)
                    {
                        response.AccessToken = string.Empty;
                        response.RefreshToken = string.Empty;
                        response.Result = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Mensajes.Add(new Mensaje("Expired tokens.", MessageClass.Danger, "ExpiredTokens"));
                        response.Mensajes.Add(new Mensaje("Tokens expirados.", MessageClass.Danger, "ExpiredTokens"));

                        return response;
                    }

                    var storedToken = await _refTokRepo.ObtenerUno(request.RefreshToken);

                    if(storedToken == null)
                    {
                        response.AccessToken = string.Empty;
                        response.RefreshToken = string.Empty;
                        response.Result = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Mensajes.Add(new Mensaje("Invalid tokens.", MessageClass.Danger, "InvalidTokens"));
                        response.Mensajes.Add(new Mensaje("Tokens inválidos.", MessageClass.Danger, "InvalidTokens"));

                        return response;
                    }

                    if(storedToken.Used || storedToken.Revoked)
                    {
                        response.AccessToken = string.Empty;
                        response.RefreshToken = string.Empty;
                        response.Result = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Mensajes.Add(new Mensaje("Invalid tokens.", MessageClass.Danger, "InvalidTokens"));
                        response.Mensajes.Add(new Mensaje("Tokens inválidos.", MessageClass.Danger, "InvalidTokens"));

                        return response;
                    }

                    var jti = tokenHandled.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value;

                    if (jti != storedToken.IdJwt)
                    {
                        response.AccessToken = string.Empty;
                        response.RefreshToken = string.Empty;
                        response.Result = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Mensajes.Add(new Mensaje("Invalid tokens.", MessageClass.Danger, "InvalidTokens"));
                        response.Mensajes.Add(new Mensaje("Tokens inválidos.", MessageClass.Danger, "InvalidTokens"));

                        return response;
                    }

                    if(storedToken.ExpiryDate < DateTime.UtcNow)
                    {
                        response.AccessToken = string.Empty;
                        response.RefreshToken = string.Empty;
                        response.Result = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Mensajes.Add(new Mensaje("Expired tokens.", MessageClass.Danger, "ExpiredTokens"));
                        response.Mensajes.Add(new Mensaje("Tokens expirados.", MessageClass.Danger, "ExpiredTokens"));

                        return response;
                    }

                    storedToken.Used = true;
                    storedToken.Revoked = true;

                    var updateResult = await _refTokRepo.Actualizar(storedToken);

                    if(updateResult == null)
                    {
                        response.AccessToken = string.Empty;
                        response.RefreshToken = string.Empty;
                        response.Result = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Mensajes.Add(new Mensaje("InternalServerError.", MessageClass.Danger, "InternalServerError"));
                        response.Mensajes.Add(new Mensaje("Error interno del servidor al momento de actualizar los tokens.", MessageClass.Danger, "InternalServerError"));

                        return response;
                    }

                    var user = await _userIdG.EncontrarPorIdAsync(storedToken.IdUser);

                    if(user == null)
                    {
                        response.AccessToken = string.Empty;
                        response.RefreshToken = string.Empty;
                        response.Result = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Mensajes.Add(new Mensaje("UserNotFound.", MessageClass.Danger, "UserNotFound"));
                        response.Mensajes.Add(new Mensaje("No se encontró al usuario luego de actualizar los tokens.", MessageClass.Danger, "UserNotFound"));

                        return response;
                    }

                    var tokenFinal = await GenerarTokenAsync(user);

                    if(tokenFinal == null)
                    {
                        response.AccessToken = string.Empty;
                        response.RefreshToken = string.Empty;
                        response.Result = false;
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.Mensajes.Add(new Mensaje("TokenError.", MessageClass.Danger, "TokenError"));
                        response.Mensajes.Add(new Mensaje("Error en la generación de tokens.", MessageClass.Danger, "UserNotFound"));

                        return response;
                    }

                    response.AccessToken = tokenFinal.AccessToken;
                    response.RefreshToken = tokenFinal.RefreshToken;
                    response.Result = true;
                    response.StatusCode = HttpStatusCode.OK;
                    response.Mensajes.Add(new Mensaje("Tokens refrescados con éxito.", MessageClass.Success, "Success"));

                }
                
                return response;
            }
            catch (Exception exc)
            {

                throw;
            }
        }
    }
}
