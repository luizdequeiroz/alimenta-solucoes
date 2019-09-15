using api.Models.Enums;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefeicaoController : ControllerBase
    {
        private readonly IRefeicaoService refeicaoService;

        public RefeicaoController(IRefeicaoService refeicaoService)
        {
            this.refeicaoService = refeicaoService;
        }

        [HttpGet("{clienteId}/{dataInicial}/{dataFinal}/{tipoRefeicao?}")]
        public async Task<IActionResult> ReadByClientIdAndInitialDateAndFinalDateAsync(int clienteId, DateTime dataInicial, DateTime dataFinal, TipoRefeicao? tipoRefeicao)
        {
            try
            {
                var refeicoes = await refeicaoService.GetByClientAndPeriodAsync(clienteId, dataInicial, dataFinal, tipoRefeicao);

                return Ok(new
                {
                    sucesso = true,
                    retorno = refeicoes
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    stack = ex,
                    erros = new string[] {
                        "Erro na consulta das refeições do cliente."
                    }
                });
            }
        }
    }
}
