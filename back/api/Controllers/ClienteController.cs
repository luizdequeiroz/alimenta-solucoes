using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> ReadAllAsync()
        {
            try
            {
                var clientes = await clienteService.GetAllAsync();

                return Ok(new
                {
                    sucesso = true,
                    retorno = clientes
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    stack = ex,
                    erros = new string[]
                    {
                        "Erro na consulta de clientes."
                    }
                });
            }
        }
    }
}