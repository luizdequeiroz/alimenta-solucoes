namespace api.Repositories.Scripts
{
    public class RefeicaoScripts
    {
        internal static readonly string SELECT_BY_CLIENT_AND_PERIOD = @"
            SELECT 
                  refnumsequencial Id
                , refdiarefeicao Dia
                , reftiporefeicao TipoString
                , refvalorrefeicao Valor
                , refhorarioentrega HorarioEntrega
                , refcliente ClienteId
                , refdatarefeicao DataRefeicao
                , clinumsequencial Id
                , clinome ClienteNome
                , clicpf ClienteCPF
                , clicnpj ClienteCNPJ
                , clitelefone ClienteTelefone
                , cliendereco ClienteEndereco
                , clienderecoentrega ClienteEnderecoEntrega
                , clipesrepresentante ClientePessoaRepresentante
            FROM 
                  tbcliente LEFT OUTER JOIN tbrefeicao ON clinumsequencial = refcliente
            WHERE 
                    clinumsequencial = @clienteId 
                AND refdatarefeicao between @dataInicial and @dataFinal
        ";
        internal static readonly string SELECT_BY_CLIENT_PERIOD_AND_TYPE = $"{SELECT_BY_CLIENT_AND_PERIOD} AND reftiporefeicao = @tipoRefeicao";
    }
}
