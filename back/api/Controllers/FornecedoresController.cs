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
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorService FornecedorService;

        public FornecedoresController(IFornecedorService FornecedorService)
        {
            this.FornecedorService = FornecedorService;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarFornecedoresAsync()
        {
            try
            {
                var Fornecedores = await FornecedorService.BuscarFornecedorAsync();
                return Ok(Fornecedores);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("pesquisarFornecedores/{nomeFornecedor}")]
        public async Task<IActionResult> pesquisarFornecedorAsync(string nomeFornecedor)
        {
            try
            {
                var Fornecedor = await FornecedorService.pesquisarFornecedorAsync(nomeFornecedor);
                return Ok(Fornecedor);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CadastrarFornecedorAsync([FromBody] Fornecedor Fornecedor)
        {
            try
            {
                var novoFornecedor = await FornecedorService.InserirFornecedorAsync(Fornecedor);
                return Created("", novoFornecedor);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{FornecedorId}")]
        public async Task<IActionResult> AtualizarFornecedorAsync(int FornecedorId, [FromBody] Fornecedor Fornecedor)
        {
            try
            {
                var FornecedorResult = await FornecedorService.BuscarFornecedorAsync(FornecedorId);
                if (FornecedorResult == null)
                    return NotFound();

                Fornecedor.Id = FornecedorId;
                await FornecedorService.AtualizarFornecedorAsync(Fornecedor);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{FornecedorId}")]
        public async Task<IActionResult> ExcluirFornecedorAsync(int FornecedorId)
        {
            try
            {
                await FornecedorService.ExcluirFornecedorAsync(new Fornecedor() { Id = FornecedorId });
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

    }
}