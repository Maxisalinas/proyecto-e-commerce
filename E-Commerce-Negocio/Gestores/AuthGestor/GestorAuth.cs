using AutoMapper;
using E_Commerce_Comun.Entidades;
using E_Commerce_Comun.Sealed;
using E_Commerce_Negocio.Config;
using E_Commerce_Negocio.DTOs.AuthDTOs;
using E_Commerce_Negocio.DTOs.UsuarioDTOs.Request;
using E_Commerce_Negocio.DTOs.UsuarioDTOs.Response;
using E_Commerce_Negocio.Gestores.JwtGestor;
using E_Commerce_Negocio.Repositorios.UsuarioIdentityRepo;
using E_Commerce_Negocio.Repositorios.UsuarioRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.AuthGestor
{
    public class GestorAuth : IGestorAuth
    {
        private readonly JwtConfig _jwtConfig;
        private readonly IRepositorioUsuario _userRepo;
        private readonly IRepositorioUsuarioIdentity _identityUserRepo;
        private readonly IGestorJwt _gestorJwt;
        private readonly IMapper _mapper;

        public GestorAuth(
            IOptions<JwtConfig> jwtConfig,
            IRepositorioUsuario userRepo,
            IMapper mapper,
            IRepositorioUsuarioIdentity identityUserRepo,
            IGestorJwt gestorJwt,
            IEmailSender emailSender)
        {
            _jwtConfig = jwtConfig.Value;
            _userRepo = userRepo;
            _mapper = mapper;
            _identityUserRepo = identityUserRepo;
            _gestorJwt = gestorJwt;
        }

        public async Task<CrearUsuarioResponseDto> Crear(CrearUsuarioRequestDto request)
        {
            var response = new CrearUsuarioResponseDto();

            try
            {
                if (request == null)
                {
                    response.AuthResult.AccessToken = string.Empty;
                    response.AuthResult.Result = false;
                    response.AuthResult.StatusCode = HttpStatusCode.BadRequest;
                    response.AuthResult.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.AuthResult.Mensajes.Add(new Mensaje("El cuerpo de la solicitud no puede ser null.", MessageClass.Danger, "NullRequest"));
                    
                    return response;
                }

                var userEntity = await _identityUserRepo.EncontrarPorEmailAsync(request.CorreoElectronico);

                if(userEntity != null)
                {
                    response.AuthResult.AccessToken = string.Empty;
                    response.AuthResult.Result = false;
                    response.AuthResult.StatusCode = HttpStatusCode.BadRequest;
                    response.AuthResult.Mensajes.Add(new Mensaje("User exists.", MessageClass.Danger, "UserExists"));
                    response.AuthResult.Mensajes.Add(new Mensaje("Ya existe un usuario registrado con el correo electrónico ingresado.", MessageClass.Danger, "UserExists"));
                    
                    return response;
                }

                var entidad = _mapper.Map<Usuario>(request);

                var entidadCreada = await _userRepo.Crear(entidad);

                if(entidadCreada == null)
                {
                    response.AuthResult.AccessToken = string.Empty;
                    response.AuthResult.Result = false;
                    response.AuthResult.StatusCode = HttpStatusCode.InternalServerError;
                    response.AuthResult.Mensajes.Add(new Mensaje("InternalServerError.", MessageClass.Danger, "InternalServerError"));
                    response.AuthResult.Mensajes.Add(new Mensaje("Ocurrió un error en el momento de registrar el usuario. Por favor, intente nuevamente.", MessageClass.Danger, "InternalServerError"));
                    
                    return response;
                }

                var identityUser = new UsuarioIdentity()
                {
                    Email = entidadCreada.CorreoElectronico,
                    UserName = entidadCreada.CorreoElectronico,
                    EmailConfirmed = false,
                    IdUsuario = entidadCreada.Id
                };

                var result = await _identityUserRepo.CrearAsync(identityUser, entidadCreada.Password);

                if (result == null)
                {
                    response.AuthResult.AccessToken = string.Empty;
                    response.AuthResult.Result = false;
                    response.AuthResult.StatusCode = HttpStatusCode.InternalServerError;
                    response.AuthResult.Mensajes.Add(new Mensaje("InternalServerError.", MessageClass.Danger, "InternalServerError"));
                    response.AuthResult.Mensajes.Add(new Mensaje("Ocurrió un error en el momento de registrar la identidad del usuario. Por favor, intente nuevamente.", MessageClass.Danger, "InternalServerError"));

                    return response;
                }

                //response.AuthResult.Token = _gestorJwt.GenerarToken(result);

                response.AuthResult.Result = true;
                response.AuthResult.StatusCode = HttpStatusCode.Created;
                response.Usuario = result;
                response.AuthResult.Mensajes.Add(new Mensaje("Success.", MessageClass.Success, "Success"));
                response.AuthResult.Mensajes.Add(new Mensaje("¡Usuario registrado con éxito!", MessageClass.Success, "Success"));
                response.AuthResult.Mensajes.Add(new Mensaje("Por favor, verifique su casilla de correo electrónico para confirmar su cuenta.", MessageClass.Success, "Success"));
                
                return response;
            }
            catch (Exception exc)
            {

                throw;
            }
            
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto request)
        {
            var response = new LoginResponseDto();

            try
            {
                if (request == null)
                {
                    response.AuthResult.AccessToken = string.Empty;
                    response.AuthResult.Result = false;
                    response.AuthResult.StatusCode = HttpStatusCode.BadRequest;
                    response.AuthResult.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.AuthResult.Mensajes.Add(new Mensaje("El cuerpo de la solicitud no puede ser null.", MessageClass.Danger, "NullRequest"));

                    return response;
                }

                var userEntity = await _identityUserRepo.EncontrarPorEmailAsync(request.CorreoElectronico);

                if (userEntity == null)
                {
                    response.AuthResult.AccessToken = string.Empty;
                    response.AuthResult.Result = false;
                    response.AuthResult.StatusCode = HttpStatusCode.NotFound;
                    response.AuthResult.Mensajes.Add(new Mensaje("UserNotFound.", MessageClass.Danger, "UserNotFound"));
                    response.AuthResult.Mensajes.Add(new Mensaje("No existe un usuario registrado con el correo electrónico ingresado.", MessageClass.Danger, "UserNotFound"));

                    return response;
                }

                var validatedEntity = await _identityUserRepo.ValidarEmailYPasswordAsync(userEntity, request.Password);

                if (validatedEntity == false)
                {
                    response.AuthResult.AccessToken = string.Empty;
                    response.AuthResult.Result = false;
                    response.AuthResult.StatusCode = HttpStatusCode.Unauthorized;
                    response.AuthResult.Mensajes.Add(new Mensaje("InvalidCredentials.", MessageClass.Danger, "InvalidCredentials"));
                    response.AuthResult.Mensajes.Add(new Mensaje("Contraseña incorrecta.", MessageClass.Danger, "InvalidCredentials"));
                    response.AuthResult.Mensajes.Add(new Mensaje("Contraseña incorrecta. Por favor, intente nuevamente.", MessageClass.Danger, "InvalidCredentials"));

                    return response;
                }

                if (!userEntity.EmailConfirmed)
                {
                    response.AuthResult.AccessToken = string.Empty;
                    response.AuthResult.Result = false;
                    response.AuthResult.StatusCode = HttpStatusCode.Unauthorized;
                    response.AuthResult.Mensajes.Add(new Mensaje("InactiveAccount.", MessageClass.Danger, "InactiveAccount"));
                    response.AuthResult.Mensajes.Add(new Mensaje("Cuenta inactiva.", MessageClass.Danger, "InactiveAccount"));
                    response.AuthResult.Mensajes.Add(new Mensaje("Por favor, recuerde verificar su casilla de correo electrónico y confirmar su cuenta.", MessageClass.Danger, "InactiveAccount"));

                    return response;
                }

                var tokens = await _gestorJwt.GenerarTokenAsync(userEntity);

                if(tokens == null || tokens.Result == false)
                {
                    response.AuthResult.AccessToken = string.Empty;
                    response.AuthResult.RefreshToken = string.Empty;
                    response.AuthResult.Result = false;
                    response.AuthResult.StatusCode = HttpStatusCode.Unauthorized;
                    response.AuthResult.Mensajes.Add(new Mensaje("InvalidTokens.", MessageClass.Danger, "InvalidTokens"));
                    response.AuthResult.Mensajes.Add(new Mensaje("Tokens inválidos.", MessageClass.Danger, "InvalidTokens"));
                    response.AuthResult.Mensajes.Add(new Mensaje("Por favor, verifique los tokens.", MessageClass.Danger, "InvalidTokens"));

                    return response;
                }

                response.AuthResult.AccessToken = tokens.AccessToken;
                response.AuthResult.RefreshToken = tokens.RefreshToken;
                response.AuthResult.Result = tokens.Result;
                response.AuthResult.StatusCode = HttpStatusCode.OK;
                response.AuthResult.Mensajes.Add(new Mensaje("Success.", MessageClass.Success, "Success"));
                response.AuthResult.Mensajes.Add(new Mensaje("¡Usuario logueado con éxito!", MessageClass.Success, "Success"));

                return response;
            }
            catch (Exception exc)
            {

                throw;
            }
        }

        public async Task<AuthResultDto> RefreshToken(TokenRequestDto request)
        {
            var response = new AuthResultDto();
            
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

                var result = await _gestorJwt.VerificarYGenerarTokenAsync(request);

                if(result == null)
                {
                    response.AccessToken = string.Empty;
                    response.RefreshToken = string.Empty;
                    response.Result = false;
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Invalid tokens.", MessageClass.Danger, "InvalidTokens"));
                    response.Mensajes.Add(new Mensaje("Los tokens proporcionados son inválidos.", MessageClass.Danger, "InvalidTokens"));

                    return response;
                }

                response = result;

                return response;
            }
            catch (Exception exc)
            {

                throw;
            }
        }
    }
}
