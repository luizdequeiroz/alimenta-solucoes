using api.Models;
using api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Services.Interfaces
{
    public interface IRefeicaoService
    {
        Task<IEnumerable<Refeicao>> GetByClientAndPeriodAsync(int clienteId, DateTime dataInicial, DateTime dataFinal, TipoRefeicao? tipoRefeicao);
    }
}
