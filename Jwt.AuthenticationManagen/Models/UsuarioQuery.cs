namespace Jwt.AuthenticationManagen.Models
{
    public class UsuarioResponseQuery
    {
        public string? Usuario { get; set; }
        public string? Nombres { get; set; }
        public string? Documento { get; set; }
        public string? IdRol { get; set; }
        public string? Key { get; set; }
        public string? TypeResponse { get; set; }
        public string? Summary { get; set; }
        public string? Message { get; set; }
        public bool? Permiso_Escritura { get; set; }
        public string? Access_token { get; set; }

    }

    public class TokenUsuarioQuery
    {

        public string? Key { get; set; }
        public string? TypeResponse { get; set; }
        public string? Summary { get; set; }
        public string? Message { get; set; }
        public string? Access_token { get; set; }
    }
}
