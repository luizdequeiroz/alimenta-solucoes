using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;
        
        public async Task<Produto> InserirProdutoAsync(Produto cliente)
        {
            await produtoRepository.InsertAsync(cliente);
            //await produtoRepository.InserirScript(cliente);
            return cliente;
        }

        public async Task<IEnumerable<Produto>> BuscarProdutosAsync()
        {
            var produtos = await produtoRepository.FindAllAsync();
            return produtos;
        }

        public async Task<IEnumerable<Produto>> pesquisarProdutosAsync(string nomeProduto)
        {
            var produtos = await produtoRepository.pesquisarProdutosAsync(nomeProduto);
            return produtos;
        }

        public async Task<Produto> BuscarProdutoAsync(int id)
        {
            var produto = await produtoRepository.FindOneAsync(new Produto() { Id = id });
            return produto;
        }

        public async Task<Produto> AtualizarProdutoAsync(Produto produto)
        {
            await produtoRepository.UpdateAsync(produto);
            return produto;
        }

        public async Task ExcluirProdutoAsync(Produto produto)
        {
            await produtoRepository.DeleteAsync(produto);
        }



    }
}
