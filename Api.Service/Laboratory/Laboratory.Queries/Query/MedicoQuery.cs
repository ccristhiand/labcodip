using Common.Utility;

namespace Laboratory.Service
{
    public class MedicoQuery
    {
        public MedicoQuery()
        {
            ListaOpciones = new List<OptionQuery>();
        }
        public int? Codigo { get; set; }
        public string? IdMedico { get; set; }
        public string? IdPersona { get; set; }

        public string? IdTipoDocu { get; set; }

        public string? NroDocumento { get; set; }

        public string? ApePaterno { get; set; }

        public string? ApeMaterno { get; set; }

        public string? Nombre { get; set; }

        public string? NombreCompleto => ApePaterno + " " + ApeMaterno + " " + Nombre;

        public DateTime? FechaNacimiento { get; set; }

        public string? IdSexo { get; set; }

        public string? Color { get; set; }

        public string? Estado { get; set; }
        public int? Edad { get; set; }

        public List<OptionQuery> ListaOpciones { get; set; }
    }
}
