﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.Scripts
{
    internal static class ProdutoScripts
    {
        internal static string BuscarProdutoScript =>
            @"SELECT 
                *
            FROM tbproduto 
            WHERE pronome like %@nomeProduto%";
    }
}
