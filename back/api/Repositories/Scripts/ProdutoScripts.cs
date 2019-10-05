using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.Scripts
{
    internal static class ProdutoScripts
    {
        internal static string BuscarScript =>
            @"SELECT 
                usunumsequencial AS Id,
                usunome AS Nome,
                ususenha AS Senha,
                usutoken AS Token,
                usuadmin AS Admin
            FROM tbusuario 
            WHERE usunome = @Login";

        
}
}
