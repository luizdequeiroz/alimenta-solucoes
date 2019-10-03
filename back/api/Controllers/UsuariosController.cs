using System;
using System.Threading.Tasks;
using api.Models;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    [Authorize("Bearer")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;
        
        public UsuariosController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [AllowAnonymous]
        [HttpPost("signIn")]
        public async Task<IActionResult> LoginAsync([FromBody] Usuario usuario)
        {
            try
            {
                var usuarioAutenticado = await usuarioService.AutenticarUsuarioAsync(usuario);
                return Ok(usuarioAutenticado);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] Usuario usuario)
        {
            try
            {
                var novoUsuario = await usuarioService.InserirUsuarioAsync(usuario);
                return Created("", novoUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarUsuariosAsync()
        {
            try
            {
                var usuarios = await usuarioService.BuscarUsuariosAsync();
                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{usuarioId}")]
        public async Task<IActionResult> AtualizarUsuarioAsync(int usuarioId, [FromBody] Usuario usuario)
        {
            try
            {
                var usuarioResult = await usuarioService.BuscarUsuarioAsync(usuarioId);
                if (usuarioResult == null)
                    return NotFound();

                usuario.Id = usuarioId;
                await usuarioService.AtualizarUsuarioAsync(usuario);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{usuarioId}")]
        public async Task<IActionResult> ExcluirUsuarioAsync(int usuarioId)
        {
            try
            {
                await usuarioService.ExcluirUsuarioAsync(new Usuario(){ Id = usuarioId });
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}