using api.Models;
using api.Models.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories.Interfaces
{
    public interface IRefeicaoRepository
    {
        Task<IEnumerable<Refeicao>> SelectByClientIdAndPeriodAsync(int clienteId, DateTime dataInicial, DateTime dataFinal);
        Task<IEnumerable<Refeicao>> SelectByClientIdPeriodAndTypeAsync(int clienteId, DateTime dataInicial, DateTime dataFinal, TipoRefeicao tipoRefeicao);
    }
}
