using Common.Utility;

namespace Laboratory.Service
{
    public class OrdenQuery
    {
        public OrdenQuery()
        {
            ListaOrdenExamen = new List<OrdenExamenQuery>();
            ListaOpciones = new List<OptionQuery>();
        }

        public string? IdOrden { get; set; }
        public string? IdOrdenExamen { get; set; }
        public string? IdPaciente { get; set; }
        public string? NroOrden { get; set; }
        public string? NroAtencion { get; set; }
        public DateTime? FechaOrden { get; set; }
        public string? StrFechaOrden => (FechaOrden == null) ? null : FechaOrden!.Value.ToString("dd/MM/yyyy");
        public DateTime? FechaResultado { get; set; }
        public string? StrFechaResultado => (FechaResultado == null) ? null : FechaResultado!.Value.ToString("dd/MM/yyyy");

        public string? IdTipoDocu { get; set; }
        public string? NroDocumento { get; set; }
        public string? HistoriaClinica { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public string? ApePaterno { get; set; }
        public string? ApeMaterno { get; set; }
        public string? Nombre { get; set; }


        public string? IdSexo { get; set; }
        public string? IdProcedencia { get; set; }
        public string? IdServicio { get; set; }
        public string? IdMedico { get; set; }

        public string? Cama { get; set; }
        public string? IdOrigen { get; set; }

        public string? NombreCompleto => ApePaterno + " " + ApeMaterno + " " + Nombre;

        public string? IdLaboratorio { get; set; }
        public string? IdArea { get; set; }

        public string? Estado { get; set; }
        public string? Color { get; set; }
        public string? UnidadMedida { get; set; }
        public string? Examen { get; set; }
        public string? Resultado { get; set; }

        public List<OrdenExamenQuery> ListaOrdenExamen { get; set; }
        public List<OptionQuery> ListaOpciones { get; set; }
    }

    public class OrdenReqQuery
    {
        public string? Valor { get; set; }
        public string? TipoOrden { get; set; }
        public string? Estado { get; set; }
        public string? Idlab { get; set; }
        public string? Idarea { get; set; }
        public string? Usuario { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }

    public class OrdenExamenQuery
    {
        public string? IdOrdenExamen { get; set; }
        public string? IdOrden { get; set; }
        public string? IdExamen { get; set; }
        public string? IdLaboratorio { get; set; }
        public string? IdArea { get; set; }


        public string? Abreviatura { get; set; }
        public string? NombreExamen { get; set; }
        public string? Resultado { get; set; }
        public string? UnidadMedida { get; set; }
        public string? Observacion { get; set; }
        public string? Referencia { get; set; }
        public DateTime? FechaResultado { get; set; }
        public string? StrFechaResultado => (FechaResultado == null) ? null : FechaResultado!.Value.ToString("dd/MM/yyyy");
        public string? Estado { get; set; }
        public string? Color { get; set; }

        public string? SimboloResulatdo { get; set; }

        public bool Validado { get; set; }
    }
}
