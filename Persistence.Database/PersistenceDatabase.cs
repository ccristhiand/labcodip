using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Database.Configuration;
using Persistence.Database.CurrentUser;
using Persistence.Database.CurrentUser.Dto;
using Persistence.Database.CurrentUser.Service;
using Persistence.Database.Procedimientos;
using Silac.Domain;
using Silac.Domain.Conf;
using Silac.Domain.Rept;
using System.Text.Json;

namespace Persistence.Database
{
    public class PersistenceDatabase : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        //schema conf
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<EquipoMedico> EquipoMedico { get; set; }
        public virtual DbSet<EquipoMedicoAnalizador> EquipoMedicoAnalizador { get; set; }
        public virtual DbSet<EquipoMedicoExamen> EquipoMedicoExamen { get; set; }
        public virtual DbSet<Examen> Examen { get; set; }
        public virtual DbSet<ExamenRango> ExamenRango { get; set; }
        public virtual DbSet<Hospital> Hospital { get; set; }
        public virtual DbSet<Laboratorio> Laboratorio { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<SistemaCliente> SistemaCliente { get; set; }
        public virtual DbSet<SistemaClienteExamen> SistemaClienteExamen { get; set; }
        public virtual DbSet<TablaMaestra> TablaMaestra { get; set; }
        public virtual DbSet<TipoMuestra> TipoMuestra { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PerfilExamen> PerfilExamen { get; set; }


        //schema crca
        public virtual DbSet<Lote> Lote { get; set; }
        public virtual DbSet<Nivel> Nivel { get; set; }
        public virtual DbSet<QCRango> QCRango { get; set; }
        public virtual DbSet<QCResultado> QCResultado { get; set; }
        public virtual DbSet<Reactivo> Reactivo { get; set; }
        public virtual DbSet<ReactivoDet> ReactivoDet { get; set; }
        public virtual DbSet<ReactivoExamen> ReactivoExamen { get; set; }


        //schema labo
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<OrdenExamen> OrdenExamen { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Procedencia> Procedencia { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<Origen> Origen { get; set; }
        public virtual DbSet<OrdenPaciente> OrdenPaciente { get; set; }

        //schema Segu
        public virtual DbSet<Navbar> Navbar { get; set; }
        public virtual DbSet<NavbarRelacion> NavbarRelacion { get; set; }
        public virtual DbSet<NavbarRelacionRol> NavbarRelacionRol { get; set; }
        public virtual DbSet<UsuarioRolPermiso> UsuarioRolPermiso { get; set; }
        public virtual DbSet<NavbarPermiso> NavbarPermiso { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioArea> UsuarioArea { get; set; }
        public virtual DbSet<UsuarioHospital> UsuarioHospital { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }

        public virtual DbSet<Tracking> Tracking { get; set; }
        public virtual DbSet<Reporte> Reportes { get; set; }

        public PersistenceDatabase(DbContextOptions<PersistenceDatabase> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var response = Metodo.GetByConnection();

            if (!string.IsNullOrEmpty(_currentUserService.IdClient))
            {
                var connection = response!.Connection.Where(y => y.IdClient == _currentUserService.IdClient)!.FirstOrDefault();

                optionsBuilder.UseSqlServer(connection!.Cns);
            }
            else
            {
                var connection = response!.Connection.FirstOrDefault();

                optionsBuilder.UseSqlServer(connection!.Cns);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ModelConfig(builder);
        }
        private void ModelConfig(ModelBuilder builder)
        {
            new Schema(builder);
            new HasData(builder);

        }
        public void CreateStoredProcedures()
        {
            Database.ExecuteSqlRaw(new Tracking_Agregar().SP_Tracking_Agregar);
            Database.ExecuteSqlRaw(new Reporte_ImprimirEtiqueta().SP_Reporte_ImprimirEtiqueta);
            Database.ExecuteSqlRaw(new Reporte_BuscarOrdenPaciente().SP_Reporte_BuscarOrdenPaciente);
            Database.ExecuteSqlRaw(new Seguridad_Credenciales().SP_Usuario_Credenciales);
            Database.ExecuteSqlRaw(new Reporte_BuscarPaciente().SP_Reporte_BuscarPaciente);
            Database.ExecuteSqlRaw(new Reporte_BuscarResultadoPaciente().SP_Reporte_BuscarResultadoPaciente);
            Database.ExecuteSqlRaw(new Reporte_ImprimirResultado().SP_Reporte_ImprimirResultado);

        }
    }
}
