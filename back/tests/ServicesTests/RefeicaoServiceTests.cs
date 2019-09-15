using api.Models;
using api.Repositories;
using api.Services;
using api.Services.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using Xunit;

namespace tests.ServicesTests
{
    public class RefeicaoServiceTests
    {
        private readonly IRefeicaoService refeicaoService;

        public RefeicaoServiceTests()
        {
            this.refeicaoService = new RefeicaoService(new RefeicaoRepository(new MySqlConnection("server=localhost;database=sysalimento;user=root;password=protego")));
        }

        [Theory(DisplayName = "Servico para selecionar refeições por id de cliente e período")]
        [InlineData("8", "2019-09-01", "2019-09-30", "2019-09-01")]
        [InlineData("11", "2019-08-01", "2019-09-30", "2019-08-12")]
        public void SelectByClientIdAndPeriodTest(string strClienteId, string strDataInicial, string strDataFinal, string expectedDateTime)
        {
            var result = refeicaoService.GetByClientAndPeriodAsync(int.Parse(strClienteId), DateTime.Parse(strDataInicial), DateTime.Parse(strDataFinal)).Result;
            Assert.NotEmpty(result);
            Assert.True(result.Count() >= 7);
            Assert.Contains(result, r => r.DataRefeicao.Equals(DateTime.Parse(expectedDateTime)));
        }
    }
}
