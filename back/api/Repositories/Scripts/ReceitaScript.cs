using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.Scripts
{
    internal static class ReceitaScripts
    {
        internal static string BuscarReceitaScript =>
            @"SELECT 
                *
            FROM tbreceita 
            WHERE recnome like %@nomeReceita%";
    }
}
