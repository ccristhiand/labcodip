using Microsoft.EntityFrameworkCore;
using Silac.Domain;
using Silac.Domain.Conf;
using Silac.Domain.Rept;


namespace Persistence.Database.Configuration
{
    public class Schema
    {
        public Schema(ModelBuilder builder)
        {
            builder.Entity<Laboratorio>().ToTable("Laboratorio", schema: "conf");
            builder.Entity<Area>().ToTable("Area", schema: "conf");
            builder.Entity<EquipoMedico>().ToTable("EquipoMedico", schema: "conf");
            builder.Entity<EquipoMedicoAnalizador>().ToTable("EquipoMedicoAnalizador", schema: "conf");
            builder.Entity<EquipoMedicoExamen>().ToTable("EquipoMedicoExamen", schema: "conf");
            builder.Entity<Examen>().ToTable("Examen", schema: "conf");
            builder.Entity<ExamenRango>().ToTable("ExamenRango", schema: "conf");
            builder.Entity<Hospital>().ToTable("Hospital", schema: "conf");
            builder.Entity<Persona>().ToTable("Persona", schema: "conf");
            builder.Entity<SistemaCliente>().ToTable("SistemaCliente", schema: "conf");
            builder.Entity<SistemaClienteExamen>().ToTable("SistemaClienteExamen", schema: "conf");
            builder.Entity<TablaMaestra>().ToTable("TablaMaestra", schema: "conf");
            builder.Entity<TipoMuestra>().ToTable("TipoMuestra", schema: "conf");
            builder.Entity<Perfil>().ToTable("Perfil", schema: "conf");
            builder.Entity<PerfilExamen>().ToTable("PerfilExamen", schema: "conf");
            builder.Entity<Medico>().ToTable("Medico", schema: "labo");
            builder.Entity<Orden>().ToTable("Orden", schema: "labo");
            builder.Entity<OrdenExamen>().ToTable("OrdenExamen", schema: "labo");
            builder.Entity<Paciente>().ToTable("Paciente", schema: "labo");
            builder.Entity<Servicio>().ToTable("Servicio", schema: "labo");
            builder.Entity<Procedencia>().ToTable("Procedencia", schema: "labo");
            builder.Entity<Origen>().ToTable("Origen", schema: "labo");
            builder.Entity<OrdenPaciente>().ToTable("OrdenPaciente", schema: "labo");
            builder.Entity<Navbar>().ToTable("Navbar", schema: "segu");
            builder.Entity<NavbarRelacion>().ToTable("NavbarRelacion", schema: "segu");
            builder.Entity<NavbarRelacionRol>().ToTable("NavbarRelacionRol", schema: "segu");
            builder.Entity<UsuarioRolPermiso>().ToTable("UsuarioRolPermiso", schema: "segu");
            builder.Entity<NavbarPermiso>().ToTable("NavbarPermiso", schema: "segu");
            builder.Entity<Permiso>().ToTable("Permiso", schema: "segu");
            builder.Entity<Rol>().ToTable("Rol", schema: "segu");
            builder.Entity<Usuario>().ToTable("Usuario", schema: "segu");
            builder.Entity<UsuarioArea>().ToTable("UsuarioArea", schema: "segu");
            builder.Entity<UsuarioHospital>().ToTable("UsuarioHospital", schema: "segu");
            builder.Entity<UsuarioRol>().ToTable("UsuarioRol", schema: "segu");

            builder.Entity<Lote>().ToTable("Lote", schema: "crca");
            builder.Entity<Nivel>().ToTable("Nivel", schema: "crca");
            builder.Entity<QCRango>().ToTable("QCRango", schema: "crca");
            builder.Entity<QCRango>().Property(x => x.RangoMinimo).HasPrecision(11, 6);
            builder.Entity<QCRango>().Property(x => x.RangoMedio).HasPrecision(11, 6);
            builder.Entity<QCRango>().Property(x => x.RangoMaximo).HasPrecision(11, 6);
            builder.Entity<QCRango>().Property(x => x.Desviacion).HasPrecision(11, 6);

            builder.Entity<QCResultado>().ToTable("QCResultado", schema: "crca");
            builder.Entity<Reactivo>().ToTable("Reactivo", schema: "crca");
            builder.Entity<ReactivoDet>().ToTable("ReactivoDet", schema: "crca");
            builder.Entity<ReactivoExamen>().ToTable("ReactivoExamen", schema: "crca");

            builder.Entity<Tracking>().ToTable("Tracking", schema: "trak");
            builder.Entity<Reporte>().ToTable("Reporte", schema: "rpt");

            builder.HasDefaultSchema("rpt");
        }
    }
}
