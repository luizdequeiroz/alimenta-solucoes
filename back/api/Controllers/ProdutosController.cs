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
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CadastrarProdutoAsync([FromBody] Produto produto)
        {
            try
            {
                var novoProduto = await produtoService.InserirProdutoAsync(produto);
                return Created("", novoProduto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{produtoId}")]
        public async Task<IActionResult> AtualizarProdutoAsync(int produtoId, [FromBody] Produto produto)
        {
            try
            {
                var produtoResult = await produtoService.BuscarProdutoAsync(produtoId);
                if (produtoResult == null)
                    return NotFound();

                produto.Id = produtoId;
                await produtoService.AtualizarProdutoAsync(produto);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> ExcluirProdutoAsync(int produtoId)
        {
            try
            {
                await produtoService.ExcluirProdutoAsync(new Produto() { Id = produtoId });
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}