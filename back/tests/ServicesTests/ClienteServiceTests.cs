using api.Models.Enums;
using api.Repositories;
using api.Services;
using api.Services.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using Xunit;

namespace tests.ServicesTests
{
    public class ClienteServiceTests
    {
        private readonly IClienteService clienteService;

        public ClienteServiceTests()
        {
            this.clienteService = new ClienteService(new ClienteRepository(new MySqlConnection("server=localhost;database=sysalimento;user=root;password=protego")));
        }

        [Theory(DisplayName = "Servico para selecionar refeições por id de cliente e período")]
        [InlineData("8", "2019-09-01", "2019-09-30", "2019-09-01")]
        [InlineData("11", "2019-08-01", "2019-09-30", "2019-08-12")]
        public void SelectByClientIdAndPeriodTest(string strClienteId, string strDataInicial, string strDataFinal, string expectedDateTime)
        {
            var result = clienteService.GetClientWithMealsByPeriodAsync(int.Parse(strClienteId), DateTime.Parse(strDataInicial), DateTime.Parse(strDataFinal), TipoRefeicao.NENHUM).Result;
            Assert.NotEmpty(result.refeicoes);
            Assert.True(result.refeicoes.Count() >= 7);
            Assert.Contains(result.refeicoes, r => r.refdatarefeicao.Equals(DateTime.Parse(expectedDateTime)));
        }
    }
}
