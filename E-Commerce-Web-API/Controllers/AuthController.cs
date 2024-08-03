using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.DTOs.UsuarioDTOs.Request;
using E_Commerce_Negocio.DTOs.UsuarioDTOs.Response;
using E_Commerce_Negocio.Gestores.AuthGestor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using E_Commerce_Negocio.Gestores.EncoderGestor;
using E_Commerce_Negocio.Gestores.UsuarioIdentityGestor;
using Microsoft.AspNetCore.Routing.Patterns;
using E_Commerce_Comun.Sealed;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using AutoMapper;
using E_Commerce_Negocio.DTOs.UsuarioDTOs;
using E_Commerce_Negocio.DTOs.AuthDTOs;
using E_Commerce_Negocio.Gestores.UsuarioGestor;

namespace E_Commerce_Web_API.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IGestorAuth _authG;
        private readonly IGestorEncoder _encoderG;
        private readonly IGestorUsuarioIdentity _userIdG;
        private readonly IGestorUsuario _userG;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _userM;
        private readonly IMapper _userIdM;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            IGestorAuth authG,
            IGestorEncoder encoderG,
            IGestorUsuarioIdentity userIdG,
            IGestorUsuario userG,
            IEmailSender emailSender,
            IMapper userM,
            IMapper userIdM,
            ILogger<AuthController> logger
            )
        {
            _authG = authG;
            _encoderG = encoderG;
            _userIdG = userIdG;
            _userG = userG;
            _emailSender = emailSender;
            _userM = userM;
            _userIdM = userIdM;
            _logger = logger;
        }

        [HttpPost("Registro", Name = "RegistroUsuario")]
        public async Task<CrearUsuarioResponseDto> Crear([FromBody] CrearUsuarioRequestDto request)
        {
            _logger.LogWarning($@"

                                Un usuario está intentando registrarse:

                                - Nombre: { request.Nombre },
                                - Apellido: { request.Apellido },
                                - CorreoElectrónico: { request.CorreoElectronico },
                                - FechaIntento: { DateTime.Now }
");
            
            var response = new CrearUsuarioResponseDto();

            try
            {
                var creationResult = await _authG.Crear(request);


                if(creationResult.AuthResult.Result == false)
                {
                    response = creationResult;
                    
                    return response;
                }
                
                await SendVerificationEmail(creationResult.Usuario);

                response.AuthResult.Result = true;
                response.AuthResult.StatusCode = HttpStatusCode.Created;
                response.Usuario = null;
                response.AuthResult.Mensajes.Add(new Mensaje("Success.", MessageClass.Success, "Success"));
                response.AuthResult.Mensajes.Add(new Mensaje("¡Usuario registrado con éxito!", MessageClass.Success, "Success"));
                response.AuthResult.Mensajes.Add(new Mensaje("Por favor, verifique su casilla de correo electrónico para confirmar su cuenta. ¡Muchas gracias!", MessageClass.Success, "Success"));

                _logger.LogWarning($@"
                                
                                El usuario logró registrarse con éxito: 
                    { await _userG.ObtenerPerfilCompletoParaTexto(creationResult.Usuario.IdUsuario) }");
            }
            catch (Exception exc)
            {

                throw;
            }

            return response;
        }

        [HttpGet("ValidarDisponibilidadEmail", Name = "ValidarDisponibilidadEmail")]
        public async Task<bool> ValidarDisponibilidadEmail(string email)
        {
            try
            {
                if(await _userIdG.EncontrarPorEmailAsync(email))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        [HttpPost("LogIn", Name = "Login")]
        public async Task<LoginResponseDto> Login([FromBody] LoginRequestDto request)
        {
            var response = new LoginResponseDto();

            try
            {
                var result = await _authG.Login(request);

                response = result;
            }
            catch (Exception exc)
            {

                throw;
            }
            return response;
        }

        [HttpGet("ConfirmEmail", Name ="ConfirmEmail")]
        public async Task<string> ConfirmEmail(string idUser, string code)
        {
            try
            {
                if(string.IsNullOrEmpty(idUser) || string.IsNullOrEmpty(code))
                {
                    return "Url de confirmación de correo eletrónico inválida.";
                }
                
                var user = await _userIdG.EncontrarPorIdAsync(idUser);

                if(user == null)
                {
                    return "No se encontró un usuario con el identificador ingresado.";
                }

                code = _encoderG.DecodificarBase64(code);

                var result = await _userIdG.ConfirmarEmailAsync(user, code);

                var status = result.Succeeded ?
                             "¡Muchas gracias por confirmar su correo electrónico!"
                           : "Ocurrió un error inesperado durante la confirmación de su correo electrónico.";

                _logger.LogWarning($@"

                                Un usuario acaba de confirmar su correo electrónico:

                                - Correo electrónico: { user.Email },
                                - FechaConfirmación: {DateTime.Now}
");

                return status;
            }
            catch (Exception exc)
            {

                throw;
            }
        }

        [HttpPost("RefreshToken", Name = "RefreshToken")]
        public async Task<AuthResultDto> RefreshToken(TokenRequestDto request)
        {
            var response = new AuthResultDto();
            
            try
            {
                var refreshResult = await _authG.RefreshToken(request);

                if(refreshResult == null)
                {
                    response.AccessToken = string.Empty;
                    response.RefreshToken = string.Empty;
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.Mensajes.Add(new Mensaje("InternalServerError", MessageClass.Danger, "InternalServerError"));

                    return response;
                }

                response = refreshResult;

                return response;
            }
            catch (Exception exc)
            {

                throw;
            }
        }

        private async Task SendVerificationEmail(UsuarioIdentity user)
        {
            var verificationCode = await _userIdG.GenerarTokenConfirmacionEmailAsync(user);
            verificationCode = _encoderG.ObtenerBytes(verificationCode);

            // Example: hhtps://localhost:8080/api/authenticationController/verifyEmail/userId=example&code=example
            var callbackUrl = $"{Request.Scheme}://{Request.Host}/api/Auth/ConfirmEmail?idUser={ user.Id }&code={ verificationCode }";

            //var emailBody = $"Por favor, confirme su cuenta ingresando <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>aquí</a>. ¡Muchas gracias!";
            var emailBody = $@"
                <html>
                <head>
                <title>E-Commerce</title>
                </head>
                <body>

                <h1>¡Hola, { await _userG.ObtenerNombrePorId(user.IdUsuario) }!</h1>
                <br>
                <h2>Por favor, confirme su cuenta ingresando <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>aquí</a>.</h2>
                <h4>¡Muchas gracias!</h4>
                <br>
                <p>Atte: <a href='{Request.Scheme}://{Request.Host}/swagger/v1/swagger.json'>E-Commerce</a>.</p>
                </body>
                </html>
            ";

            //await _emailSender.SendEmailAsync(user.Email, "Por favor, confirme su correo electrónico. ¡Muchas gracias! Atte: E-Commerce.", emailBody);
            await _emailSender.SendEmailAsync(user.Email, "Confirmación de correo electrónico - E-Commerce", emailBody);

        }
    }
}
