using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.Scripts
{
    internal static class FornecedorScripts
    {
        internal static string BuscarFornecedorScript =>
            @"SELECT 
                *
            FROM tbfornecedor 
            WHERE fornome like %@nomeFornecedor%";
    }
}
