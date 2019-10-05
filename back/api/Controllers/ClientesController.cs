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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClientesController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarClientesAsync()
        {
            try
            {
                var clientes = await clienteService.BuscarClientesAsync();
                return Ok(clientes);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> BuscarClientePorIdAsync(int clienteId)
        {
            try
            {
                var cliente = await clienteService.BuscarClientePorIdAsync(clienteId);
                if (cliente == null)
                    return NotFound();
                
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InserirClienteAsync([FromBody] Cliente cliente)
        {
            try
            {
                var clienteResult = await clienteService.InserirClienteAsync(cliente);
                
                return Created($"{Request.Path}{clienteResult.Id}", clienteResult);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{clienteId}")]
        public async Task<IActionResult> AtualizarClienteAsync(int clienteId, [FromBody] Cliente cliente)
        {
            try
            {
                var clienteResult = await clienteService.BuscarClientePorIdAsync(clienteId);
                if (cliente == null)
                    return NotFound();
                
                cliente.Id = clienteId;
                await clienteService.AtualizarClienteAsync(cliente);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("{clienteId}/desativar")]
        public async Task<IActionResult> DesativarClienteAsync(int clienteId)
        {
            try
            {
                var cliente = await clienteService.BuscarClientePorIdAsync(clienteId);
                if (cliente == null)
                    return NotFound();
                
                await clienteService.DesativarClienteAsync(cliente);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}