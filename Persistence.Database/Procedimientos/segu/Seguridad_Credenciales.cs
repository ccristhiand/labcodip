namespace Persistence.Database.Procedimientos
{
    public class Seguridad_Credenciales
    {
        public string SP_Usuario_Credenciales { get; } =
            @"CREATE OR ALTER PROC [segu].[Usuario_Credenciales]
                @user VARCHAR(20),
                @contrasenia VARCHAR(50)

                AS
                select US.UserName Usuario, PE.ApePaterno+ ' '+PE.Nombre Nombres, PE.NroDocumento Documento, UR.IdRol,US.Permiso_Escritura from [segu].[Usuario] US
                INNER JOIN [conf].[Persona] PE ON US.IdPersona = PE.IdPersona
                INNER JOIN [segu].[UsuarioRol] UR ON US.IdUsuario = UR.IdUsuario
                WHERE 
                US.UserName= @user AND US.[Password]= @contrasenia";
    }
}
