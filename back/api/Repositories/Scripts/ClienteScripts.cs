namespace api.Repositories.Scripts
{
    public class ClienteScripts
    {
        internal static readonly string SELECT_ALL = @"
            SELECT 
                  clinumsequencial Id
                , clinome Nome
                , clicpf CPF
                , clicnpj CNPJ
                , clitelefone Telefone
                , cliendereco EnderecoId
                , clienderecoentrega EnderecoEntregaId
                , clipesrepresentante PessoaRepresentanteId
            FROM 
                  tbcliente
            ";
    }
}
