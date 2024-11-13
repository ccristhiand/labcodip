using System.ComponentModel.DataAnnotations;

namespace Common.Utility
{
    public class CadenaConexion
    {
        public string? Id { get; set; }
        public string? Nombre { get; set; }
        public string? NombreBD { get; set; }
        public string? Cns { get; set; }
    }

    public class OptionQuery
    {
        public string? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo { get; set; }
    }

    public class SecurityParameter
    {
        public const string passPhrase = "S1st3m4S";
        public const string saltValue = "@4n4l1t1c0s@";
        public const string hashAlgorithm = "SHA1";
        public const int passwordIterations = 856;
        public const string initVector = "@1B2c3D4e5F6g7H8";
        public const int keySize = 256;
        public const string keyInitial = "ey|";
        public const string keyFinal = "|zu";
    }

    public class ResponseCreateCommand
    {
        public string? Key { get; set; }
        public string? TypeResponse { get; set; }
        public string? Summary { get; set; }
        public string? Message { get; set; }
        public string? Id { get; set; }
    }

    public class RequestReport
    {
        public RequestReport()
        {
            Data = new List<string>();
            TipoMuestra = new List<string>();
        }

        public string? Valor { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public List<string>? Data { get; set; }
        public List<string>? TipoMuestra { get; set; }
    }

    public class ResponseReport
    {
        public string? data { get; set; }
        public string? name { get; set; }
    }

    public class SilacCommand
    {
        [Required(ErrorMessage = "IdLaboratorio requerido")]
        public string? IdLaboratorio { get; set; }

        [Required(ErrorMessage = "IdArea requerido")]
        public string? IdArea { get; set; }

        public string? user { get; set; }
    }
    public class ConfigCommandArea
    {
        [Required(ErrorMessage = "IdLaboratorio requerido")]
        public string? IdLaboratorio { get; set; }

        public string? user { get; set; }
    }
    public class ConfigCommandLaboratorio
    {
        [Required(ErrorMessage = "IdArea requerido")]
        public string? IdArea { get; set; }

        public string? user { get; set; }
    }

}
