using api.Repositories;
using api.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using Xunit;

namespace tests.RepositoriesTests
{
    public class RefeicaoRepositoryTests
    {
        private readonly IRefeicaoRepository refeicaoRepository;

        public RefeicaoRepositoryTests()
        {
            refeicaoRepository = new RefeicaoRepository(new MySqlConnection("server=localhost;database=sysalimento;user=root;password=protego"));
        }

        [Theory(DisplayName = "Selecionar refeições por id de cliente e período (data inicial e data final)")]
        [InlineData("8", "2019-09-01", "2019-09-30")]
        public void SelectByClientIdAndPeriodTest(string strClienteId, string strDataInicial, string strDataFinal)
        {
            var result = refeicaoRepository.SelectByClientIdAndPeriodAsync(int.Parse(strClienteId), DateTime.Parse(strDataInicial), DateTime.Parse(strDataFinal)).Result;
            Assert.NotEmpty(result);
        }
    }
}
