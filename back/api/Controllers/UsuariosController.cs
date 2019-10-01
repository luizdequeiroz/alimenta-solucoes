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
    }
}