using Common.Utility;

namespace Configuration.Service.Queries.Query
{
    public class EquipoMedicoQuery
    {
        public EquipoMedicoQuery()
        {
            ListaOpciones = new List<OptionQuery>();
            ListaEquipoMedicoAnalizador = new List<EquipoMedicoAnalizadorQuery>();
        }
        public string? IdEquipoMedico { get; set; }
        public int? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? NombreLaboratorio { get; set; }
        public string? NombreArea { get; set; }
        public string? Detalle { get; set; }
        public string? Estado { get; set; }
        public string? Color { get; set; }
        public string? IdLaboratorio { get; set; }
        public string? IdArea { get; set; }

        public List<OptionQuery> ListaOpciones { get; set; }
        public List<EquipoMedicoAnalizadorQuery> ListaEquipoMedicoAnalizador { get; set; }
    }
    public class EquipoMedicoAnalizadorQuery
    {
        public string? IdEquipoMedicoAnalizador { get; set; }
        public string? IdEquipoMedico { get; set; }
        public string? SerialPuerto { get; set; }
        public int? SerialBaudrate { get; set; }
        public int? SerialDataBit { get; set; }
        public string? Estado { get; set; }
    }
}
