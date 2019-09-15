using api.Models;
using api.Models.Enums;
using api.Repositories.Interfaces;
using api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class RefeicaoService : IRefeicaoService
    {
        private readonly IRefeicaoRepository refeicaoRepository;

        public RefeicaoService(IRefeicaoRepository refeicaoRepository)
        {
            this.refeicaoRepository = refeicaoRepository;
        }

        public async Task<IEnumerable<Refeicao>> GetByClientAndPeriodAsync(int clienteId, DateTime dataInicial, DateTime dataFinal, TipoRefeicao? tipoRefeicao)
        {
            var periodInterval = dataFinal.Subtract(dataInicial).Days;
            periodInterval = periodInterval < 7 ? 7 : periodInterval;

            var todosDias = new List<Refeicao>();
            for (var i = 0; i < periodInterval; i++)
            {
                todosDias.Add(new Refeicao
                {
                    DataRefeicao = dataInicial.AddDays(i)
                });
            }

            IEnumerable<Refeicao> result;
            if (tipoRefeicao == null)
            {
                result = await refeicaoRepository.SelectByClientIdAndPeriodAsync(clienteId, dataInicial, dataFinal);
            }
            else
            {
                result = await refeicaoRepository.SelectByClientIdPeriodAndTypeAsync(clienteId, dataInicial, dataFinal, (TipoRefeicao)tipoRefeicao);
            }

            foreach(var dia in result)
            {
                todosDias = todosDias.Select(diaVazio =>
                {
                    if(diaVazio.DataRefeicao == dia.DataRefeicao)
                    {
                        return dia;
                    }
                    else
                    {
                        return diaVazio;
                    }
                }).ToList();
            }

            return todosDias;
        }
    }
}
