using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ReceitasController : Controller
    {
        private readonly IReceitaService receitaService;

        public ReceitasController(IReceitaService receitaService)
        {
            this.receitaService = receitaService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarReceitasAsync()
        {
            try
            {
                var receitas = await receitaService.BuscarReceitaAsync();
                return Ok(receitas);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("pesquisarReceitas/{nomeReceitas}")]
        public async Task<IActionResult> pesquisarReceitasAsync(string nomeReceita)
        {
            try
            {
                var receitas = await receitaService.pesquisarReceitaAsync(nomeReceita);
                return Ok(receitas);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CadastrarProdutoAsync([FromBody] Receita receitas)
        {
            try
            {
                var novaReceita = await receitaService.InserirReceitaAsync(receitas);
                return Created("", novaReceita);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{receitaId}")]
        public async Task<IActionResult> AtualizarProdutoAsync(int receitaId, [FromBody] Receita receita)
        {
            try
            {
                var produtoResult = await receitaService.BuscarReceitaAsync(receitaId);
                if (produtoResult == null)
                    return NotFound();

                receita.Id = receitaId;
                await receitaService.AtualizarReceitaAsync(receita);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{receitaId}")]
        public async Task<IActionResult> ExcluirProdutoAsync(int receitaId)
        {
            try
            {
                await receitaService.ExcluirReceitaAsync(new Receita() { Id = receitaId });
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}