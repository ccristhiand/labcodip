using Common.Utility;
using System.ComponentModel.DataAnnotations;

namespace Laboratory.Service.EventHandlers
{
    public class OrdenCreateCommand : SilacCommand
    {
        public OrdenCreateCommand()
        {
            ListaIdOrdenExamenQuery = new List<string>();
            ListaOrdenExamenQuery = new List<OrdenExamenCreateCommand>();
        }

        public string? NroOrden { get; set; }
        public string? NroAtencion { get; set; }
        public DateTime? FechaOrden { get; set; }


        public string? IdTipoDocu { get; set; }

        [Required(ErrorMessage = "NroDocumento requerido")]
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
        public string? Idperfil { get; set; }
        public string? NombrePerfil { get; set; }

        public List<string> ListaIdOrdenExamenQuery { get; set; }
        public List<OrdenExamenCreateCommand>? ListaOrdenExamenQuery { get; set; }
    }

    public class OrdenUpdateCommand : SilacCommand
    {
        public OrdenUpdateCommand()
        {
            ListaIdOrdenExamenQuery = new List<string>();
        }
        public string? Cama { get; set; }
        public DateTime? FechaOrden { get; set; }
        public string? NroAtencion { get; set; }
        public string? HistoriaClinica { get; set; }
        public string? IdMedico { get; set; }
        public string? IdProcedencia { get; set; }
        public string? IdServicio { get; set; }
        public string? IdOrigen { get; set; }

        public List<string> ListaIdOrdenExamenQuery { get; set; }
    }

    public class OrdenAddCommand : SilacCommand
    {
        public OrdenAddCommand()
        {
            ListaIdOrdenExamenQuery = new List<string>();
        }

        public List<string> ListaIdOrdenExamenQuery { get; set; }
    }

    public class OrdenValidateCommand
    {
        public OrdenValidateCommand()
        {
            ListaOrdenExamenQuery = new List<OrdenExamenCreateCommand>();
        }

        public string? Observacion { get; set; }
        public string? user { get; set; }
        public string? idArea { get; set; }
        public List<OrdenExamenCreateCommand> ListaOrdenExamenQuery { get; set; }
    }


    public class OrdenExamenCreateCommand
    {
        public string? IdExamen { get; set; }
        public string? IdOrdenExamen { get; set; }
        public string? Resultado { get; set; }
        public string? Idperfil { get; set; }
        public string? NombrePerfil { get; set; }

    }
}
