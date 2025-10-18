using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuarioApp.Domain.Dtos.Requests;
using UsuarioApp.Domain.Dtos.Responses;
using UsuarioApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Dtos.Requests;


namespace UsuarioApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarContaRequest), 200)]
        public IActionResult Criar([FromBody] CriarContaRequest request)
        {
            try
            {
                var usuario = _usuarioService.Criar(request);
                return Ok(usuario);
            }
            catch(ValidationException e)
            {
                 return BadRequest(e.Errors.Select(e=> e.PropertyName + ": " + e.ErrorMessage));
            }
            catch(ApplicationException e)
            {
                return BadRequest(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(AutenticarUsuarioResponse), 200)]
        public IActionResult Autenticar([FromBody] AutenticarUsuarioRequest request)
        {
            try
            {
                return Ok(_usuarioService.Autenticar(request));
            }
            catch(ApplicationException e)
            {
                return StatusCode(401, e.Message);

            }catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
