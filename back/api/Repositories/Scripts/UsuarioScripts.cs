namespace api.Repositories.Scripts
{
    internal static class UsuarioScripts
    {
        internal static string BuscarUsuarioPorLoginScript => 
            @"SELECT 
                usunumsequencial AS Id,
                usunome AS Nome,
                ususenha AS Senha,
                usutoken AS Token,
                usuadmin AS Admin
            FROM tbusuario 
            WHERE usunome = @Login";
        
        internal static string BuscarUsuarioPorLoginESenhaScript => 
            $@"{BuscarUsuarioPorLoginScript} 
                AND ususenha = @Senha";
    }
}