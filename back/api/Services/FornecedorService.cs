using api.Models;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace api.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository FornecedorRepository;

        public async Task<Fornecedor> InserirFornecedorAsync(Fornecedor Fornecedor)
        {
            await FornecedorRepository.InsertAsync(Fornecedor);
            return Fornecedor;
        }

        public async Task<IEnumerable<Fornecedor>> BuscarFornecedorAsync()
        {
            var Fornecedors = await FornecedorRepository.FindAllAsync();
            return Fornecedors;
        }

        public async Task<IEnumerable<Fornecedor>> pesquisarFornecedorAsync(string nomeFornecedor)
        {
            var Fornecedors = await FornecedorRepository.pesquisarFornecedorAsync(nomeFornecedor);
            return Fornecedors;
        }

        public async Task<Fornecedor> BuscarFornecedorAsync(int id)
        {
            var Fornecedor = await FornecedorRepository.FindOneAsync(new Fornecedor() { Id = id });
            return Fornecedor;
        }

        public async Task<Fornecedor> AtualizarFornecedorAsync(Fornecedor Fornecedor)
        {
            await FornecedorRepository.UpdateAsync(Fornecedor);
            return Fornecedor;
        }

        public async Task ExcluirFornecedorAsync(Fornecedor Fornecedor)
        {
            await FornecedorRepository.DeleteAsync(Fornecedor);
        }


    }

}
