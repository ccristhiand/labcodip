using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Database.Migrations
{
    /// <inheritdoc />
    public partial class Inicio01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "conf");

            migrationBuilder.EnsureSchema(
                name: "crca");

            migrationBuilder.EnsureSchema(
                name: "labo");

            migrationBuilder.EnsureSchema(
                name: "segu");

            migrationBuilder.EnsureSchema(
                name: "rpt");

            migrationBuilder.EnsureSchema(
                name: "trak");

            migrationBuilder.CreateTable(
                name: "EquipoMedico",
                schema: "conf",
                columns: table => new
                {
                    IdEquipoMedico = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Detalle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdLaboratorio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdArea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoMedico", x => x.IdEquipoMedico);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                schema: "conf",
                columns: table => new
                {
                    IdHospital = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CodigoHospital = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SubTitulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PiePagina = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Foto = table.Column<byte>(type: "tinyint", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.IdHospital);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                schema: "conf",
                columns: table => new
                {
                    IdLaboratorio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CodigoLaboratorio = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorio", x => x.IdLaboratorio);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                schema: "crca",
                columns: table => new
                {
                    IdLote = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdReactivoDet = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaExpiracion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.IdLote);
                });

            migrationBuilder.CreateTable(
                name: "Navbar",
                schema: "segu",
                columns: table => new
                {
                    IdNavbar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    icon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    routerlink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoMenu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navbar", x => x.IdNavbar);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                schema: "crca",
                columns: table => new
                {
                    IdNivel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdReactivoDet = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.IdNivel);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                schema: "labo",
                columns: table => new
                {
                    IdOrden = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NroAtencion = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    NroOrden = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraOrden = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Cama = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.IdOrden);
                });

            migrationBuilder.CreateTable(
                name: "Origen",
                schema: "labo",
                columns: table => new
                {
                    IdOrigen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origen", x => x.IdOrigen);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                schema: "conf",
                columns: table => new
                {
                    IdPerfil = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                schema: "segu",
                columns: table => new
                {
                    IdPermiso = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.IdPermiso);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                schema: "conf",
                columns: table => new
                {
                    IdPersona = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdTipoDocu = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    NroDocumento = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ApePaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApeMaterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdSexo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IdPersona);
                });

            migrationBuilder.CreateTable(
                name: "Procedencia",
                schema: "labo",
                columns: table => new
                {
                    IdProcedencia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedencia", x => x.IdProcedencia);
                });

            migrationBuilder.CreateTable(
                name: "QCResultado",
                schema: "crca",
                columns: table => new
                {
                    IdQCResultado = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdEquipoMedico = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdReactivoDet = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdLote = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdNivel = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Resultado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraResultado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCResultado", x => x.IdQCResultado);
                });

            migrationBuilder.CreateTable(
                name: "Reactivo",
                schema: "crca",
                columns: table => new
                {
                    IdReactivo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdEquipoMedico = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdModo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactivo", x => x.IdReactivo);
                });

            migrationBuilder.CreateTable(
                name: "Reporte",
                schema: "rpt",
                columns: table => new
                {
                    IdReporte = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.IdReporte);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "segu",
                columns: table => new
                {
                    IdRol = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                schema: "labo",
                columns: table => new
                {
                    IdServicio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.IdServicio);
                });

            migrationBuilder.CreateTable(
                name: "SistemaCliente",
                schema: "conf",
                columns: table => new
                {
                    IdSistemaCliente = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Server = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BaseDeDatos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contrasena = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdTipoBaseDato = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaCliente", x => x.IdSistemaCliente);
                });

            migrationBuilder.CreateTable(
                name: "TablaMaestra",
                schema: "conf",
                columns: table => new
                {
                    IdTablaMaestra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tabla = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TablaMaestra", x => x.IdTablaMaestra);
                });

            migrationBuilder.CreateTable(
                name: "TipoMuestra",
                schema: "conf",
                columns: table => new
                {
                    IdTipoMuestra = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CodigoTipoMuestra = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMuestra", x => x.IdTipoMuestra);
                });

            migrationBuilder.CreateTable(
                name: "Tracking",
                schema: "trak",
                columns: table => new
                {
                    IdTracking = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoMuestra = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdOrden = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NroOrden = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdOrdenExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DocumentoPaciente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NombrePaciente = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ApellidoPaternoPaciente = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ApellidoMaternoPaciente = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    EstadoImpresionEtiqueta = table.Column<bool>(type: "bit", nullable: true),
                    UsuarioImpresionEtiqueta = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FechaImpresionEtiqueta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacionImpresionEtiqueta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoLecturaEtiqueta = table.Column<bool>(type: "bit", nullable: true),
                    UsuarioLecturaEtiqueta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaLecturaEtiqueta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacionLecturaEtiqueta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoEnvioResultados = table.Column<bool>(type: "bit", nullable: true),
                    UsuarioEnvioResultados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEnvioResultados = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacionEnvioResultados = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoPrevalidacion = table.Column<bool>(type: "bit", nullable: true),
                    UsuarioPrevalidacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPrevalidacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacionPrevalidacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoValidacion = table.Column<bool>(type: "bit", nullable: true),
                    UsuarioValidacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaValidacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacionValidacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracking", x => x.IdTracking);
                });

            migrationBuilder.CreateTable(
                name: "EquipoMedicoAnalizador",
                schema: "conf",
                columns: table => new
                {
                    IdEquipoMedicoAnalizador = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdEquipoMedico = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SerialPuerto = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    SerialBaudrate = table.Column<int>(type: "int", nullable: true),
                    SerialDataBit = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoMedicoAnalizador", x => x.IdEquipoMedicoAnalizador);
                    table.ForeignKey(
                        name: "FK_EquipoMedicoAnalizador_EquipoMedico_IdEquipoMedico",
                        column: x => x.IdEquipoMedico,
                        principalSchema: "conf",
                        principalTable: "EquipoMedico",
                        principalColumn: "IdEquipoMedico");
                });

            migrationBuilder.CreateTable(
                name: "Area",
                schema: "conf",
                columns: table => new
                {
                    IdArea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    IdLaboratorio = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.IdArea);
                    table.ForeignKey(
                        name: "FK_Area_Laboratorio_IdLaboratorio",
                        column: x => x.IdLaboratorio,
                        principalSchema: "conf",
                        principalTable: "Laboratorio",
                        principalColumn: "IdLaboratorio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NavbarPermiso",
                schema: "segu",
                columns: table => new
                {
                    IdNavbarPermiso = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdNavbar = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdPerfil = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavbarPermiso", x => x.IdNavbarPermiso);
                    table.ForeignKey(
                        name: "FK_NavbarPermiso_Navbar_IdNavbar",
                        column: x => x.IdNavbar,
                        principalSchema: "segu",
                        principalTable: "Navbar",
                        principalColumn: "IdNavbar");
                });

            migrationBuilder.CreateTable(
                name: "NavbarRelacion",
                schema: "segu",
                columns: table => new
                {
                    IdNavbarRelacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNavbarPrincipal = table.Column<int>(type: "int", nullable: true),
                    IdNavbarSecundario = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavbarRelacion", x => x.IdNavbarRelacion);
                    table.ForeignKey(
                        name: "FK_NavbarRelacion_Navbar_IdNavbarPrincipal",
                        column: x => x.IdNavbarPrincipal,
                        principalSchema: "segu",
                        principalTable: "Navbar",
                        principalColumn: "IdNavbar");
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                schema: "labo",
                columns: table => new
                {
                    IdMedico = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdPersona = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_Medico_Persona_IdPersona",
                        column: x => x.IdPersona,
                        principalSchema: "conf",
                        principalTable: "Persona",
                        principalColumn: "IdPersona");
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                schema: "labo",
                columns: table => new
                {
                    IdPaciente = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdPersona = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdLaboratorio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdArea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_Paciente_Persona_IdPersona",
                        column: x => x.IdPersona,
                        principalSchema: "conf",
                        principalTable: "Persona",
                        principalColumn: "IdPersona");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "segu",
                columns: table => new
                {
                    IdUsuario = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdPersona = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CodExterno = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Primer_acceso = table.Column<byte>(type: "tinyint", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Permiso_Escritura = table.Column<bool>(type: "bit", nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona_IdPersona",
                        column: x => x.IdPersona,
                        principalSchema: "conf",
                        principalTable: "Persona",
                        principalColumn: "IdPersona");
                });

            migrationBuilder.CreateTable(
                name: "Examen",
                schema: "conf",
                columns: table => new
                {
                    IdExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdTipoMuestra = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdArea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Calculado = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Abreviatura = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UnidadMedida = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CantidadDecimal = table.Column<int>(type: "int", nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    TiempoTrackingMin = table.Column<int>(type: "int", nullable: true),
                    RangoMostrar = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TipoCongRango = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examen", x => x.IdExamen);
                    table.ForeignKey(
                        name: "FK_Examen_Area_IdArea",
                        column: x => x.IdArea,
                        principalSchema: "conf",
                        principalTable: "Area",
                        principalColumn: "IdArea");
                    table.ForeignKey(
                        name: "FK_Examen_TipoMuestra_IdTipoMuestra",
                        column: x => x.IdTipoMuestra,
                        principalSchema: "conf",
                        principalTable: "TipoMuestra",
                        principalColumn: "IdTipoMuestra");
                });

            migrationBuilder.CreateTable(
                name: "NavbarRelacionRol",
                schema: "segu",
                columns: table => new
                {
                    IdNavbarRelacionRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNavbarRelacion = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    navbarRelacionIdNavbarRelacion = table.Column<int>(type: "int", nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavbarRelacionRol", x => x.IdNavbarRelacionRol);
                    table.ForeignKey(
                        name: "FK_NavbarRelacionRol_NavbarRelacion_navbarRelacionIdNavbarRelacion",
                        column: x => x.navbarRelacionIdNavbarRelacion,
                        principalSchema: "segu",
                        principalTable: "NavbarRelacion",
                        principalColumn: "IdNavbarRelacion");
                    table.ForeignKey(
                        name: "FK_NavbarRelacionRol_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "segu",
                        principalTable: "Rol",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "OrdenPaciente",
                schema: "labo",
                columns: table => new
                {
                    IdOrdenPaciente = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HistoriaClinica = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IdPaciente = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdOrden = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdMedico = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdProcedencia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdServicio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdOrigen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdLaboratorio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdArea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenPaciente", x => x.IdOrdenPaciente);
                    table.ForeignKey(
                        name: "FK_OrdenPaciente_Medico_IdMedico",
                        column: x => x.IdMedico,
                        principalSchema: "labo",
                        principalTable: "Medico",
                        principalColumn: "IdMedico");
                    table.ForeignKey(
                        name: "FK_OrdenPaciente_Orden_IdOrden",
                        column: x => x.IdOrden,
                        principalSchema: "labo",
                        principalTable: "Orden",
                        principalColumn: "IdOrden");
                    table.ForeignKey(
                        name: "FK_OrdenPaciente_Origen_IdOrigen",
                        column: x => x.IdOrigen,
                        principalSchema: "labo",
                        principalTable: "Origen",
                        principalColumn: "IdOrigen");
                    table.ForeignKey(
                        name: "FK_OrdenPaciente_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalSchema: "labo",
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente");
                    table.ForeignKey(
                        name: "FK_OrdenPaciente_Procedencia_IdProcedencia",
                        column: x => x.IdProcedencia,
                        principalSchema: "labo",
                        principalTable: "Procedencia",
                        principalColumn: "IdProcedencia");
                    table.ForeignKey(
                        name: "FK_OrdenPaciente_Servicio_IdServicio",
                        column: x => x.IdServicio,
                        principalSchema: "labo",
                        principalTable: "Servicio",
                        principalColumn: "IdServicio");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioArea",
                schema: "segu",
                columns: table => new
                {
                    IdUsuarioArea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdArea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioArea", x => x.IdUsuarioArea);
                    table.ForeignKey(
                        name: "FK_UsuarioArea_Area_IdArea",
                        column: x => x.IdArea,
                        principalSchema: "conf",
                        principalTable: "Area",
                        principalColumn: "IdArea");
                    table.ForeignKey(
                        name: "FK_UsuarioArea_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "segu",
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioHospital",
                schema: "segu",
                columns: table => new
                {
                    IdUsuarioHospital = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    IdHospital = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioHospital", x => x.IdUsuarioHospital);
                    table.ForeignKey(
                        name: "FK_UsuarioHospital_Hospital_IdHospital",
                        column: x => x.IdHospital,
                        principalSchema: "conf",
                        principalTable: "Hospital",
                        principalColumn: "IdHospital");
                    table.ForeignKey(
                        name: "FK_UsuarioHospital_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "segu",
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                schema: "segu",
                columns: table => new
                {
                    IdUsuarioRol = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdUsuario = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    IdRol = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRol", x => x.IdUsuarioRol);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Rol_IdRol",
                        column: x => x.IdRol,
                        principalSchema: "segu",
                        principalTable: "Rol",
                        principalColumn: "IdRol");
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "segu",
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "EquipoMedicoExamen",
                schema: "conf",
                columns: table => new
                {
                    IdEquipoMedicoExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdEquipoMedico = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CodRecibe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CodDevuelve = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoMedicoExamen", x => x.IdEquipoMedicoExamen);
                    table.ForeignKey(
                        name: "FK_EquipoMedicoExamen_EquipoMedico_IdEquipoMedico",
                        column: x => x.IdEquipoMedico,
                        principalSchema: "conf",
                        principalTable: "EquipoMedico",
                        principalColumn: "IdEquipoMedico");
                    table.ForeignKey(
                        name: "FK_EquipoMedicoExamen_Examen_IdExamen",
                        column: x => x.IdExamen,
                        principalSchema: "conf",
                        principalTable: "Examen",
                        principalColumn: "IdExamen");
                });

            migrationBuilder.CreateTable(
                name: "ExamenRango",
                schema: "conf",
                columns: table => new
                {
                    IdExamenRango = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EdadInicio = table.Column<int>(type: "int", nullable: true),
                    EdadFinal = table.Column<int>(type: "int", nullable: true),
                    ValorMaximo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SigComparativo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ValorMinimo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IdInterpretado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenRango", x => x.IdExamenRango);
                    table.ForeignKey(
                        name: "FK_ExamenRango_Examen_IdExamen",
                        column: x => x.IdExamen,
                        principalSchema: "conf",
                        principalTable: "Examen",
                        principalColumn: "IdExamen");
                });

            migrationBuilder.CreateTable(
                name: "OrdenExamen",
                schema: "labo",
                columns: table => new
                {
                    IdOrdenExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdOrden = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Idperfil = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NombrePerfil = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Resultado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Observacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UsuarioValMed = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FechaUsuarioValMed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoUsuarioMed = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    UsuarioValTec = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FechaUsuarioValTec = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoUsuarioTec = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    SwtResultsSGSS = table.Column<int>(type: "int", nullable: true),
                    IntentoSGSS = table.Column<int>(type: "int", nullable: true),
                    MensajeSGSS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdItem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdLaboratorio = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdArea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenExamen", x => x.IdOrdenExamen);
                    table.ForeignKey(
                        name: "FK_OrdenExamen_Examen_IdExamen",
                        column: x => x.IdExamen,
                        principalSchema: "conf",
                        principalTable: "Examen",
                        principalColumn: "IdExamen");
                    table.ForeignKey(
                        name: "FK_OrdenExamen_Orden_IdOrden",
                        column: x => x.IdOrden,
                        principalSchema: "labo",
                        principalTable: "Orden",
                        principalColumn: "IdOrden");
                    table.ForeignKey(
                        name: "FK_OrdenExamen_Perfil_Idperfil",
                        column: x => x.Idperfil,
                        principalSchema: "conf",
                        principalTable: "Perfil",
                        principalColumn: "IdPerfil");
                });

            migrationBuilder.CreateTable(
                name: "PerfilExamen",
                schema: "conf",
                columns: table => new
                {
                    IdPerfilExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdPerfil = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    IdExamen = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilExamen", x => x.IdPerfilExamen);
                    table.ForeignKey(
                        name: "FK_PerfilExamen_Examen_IdExamen",
                        column: x => x.IdExamen,
                        principalSchema: "conf",
                        principalTable: "Examen",
                        principalColumn: "IdExamen");
                    table.ForeignKey(
                        name: "FK_PerfilExamen_Perfil_IdPerfil",
                        column: x => x.IdPerfil,
                        principalSchema: "conf",
                        principalTable: "Perfil",
                        principalColumn: "IdPerfil");
                });

            migrationBuilder.CreateTable(
                name: "QCRango",
                schema: "crca",
                columns: table => new
                {
                    IdQCRango = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdReactivoDet = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdExamen = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    IdLote = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    IdNivel = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    RangoMinimo = table.Column<decimal>(type: "decimal(18,6)", precision: 11, scale: 6, nullable: true),
                    RangoMedio = table.Column<decimal>(type: "decimal(18,6)", precision: 11, scale: 6, nullable: true),
                    RangoMaximo = table.Column<decimal>(type: "decimal(18,6)", precision: 11, scale: 6, nullable: true),
                    Desviacion = table.Column<decimal>(type: "decimal(18,6)", precision: 11, scale: 6, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCRango", x => x.IdQCRango);
                    table.ForeignKey(
                        name: "FK_QCRango_Examen_IdExamen",
                        column: x => x.IdExamen,
                        principalSchema: "conf",
                        principalTable: "Examen",
                        principalColumn: "IdExamen");
                    table.ForeignKey(
                        name: "FK_QCRango_Lote_IdLote",
                        column: x => x.IdLote,
                        principalSchema: "crca",
                        principalTable: "Lote",
                        principalColumn: "IdLote");
                    table.ForeignKey(
                        name: "FK_QCRango_Nivel_IdNivel",
                        column: x => x.IdNivel,
                        principalSchema: "crca",
                        principalTable: "Nivel",
                        principalColumn: "IdNivel");
                });

            migrationBuilder.CreateTable(
                name: "ReactivoDet",
                schema: "crca",
                columns: table => new
                {
                    IdReactivoDet = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdReactivo = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    IdExamen = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactivoDet", x => x.IdReactivoDet);
                    table.ForeignKey(
                        name: "FK_ReactivoDet_Examen_IdExamen",
                        column: x => x.IdExamen,
                        principalSchema: "conf",
                        principalTable: "Examen",
                        principalColumn: "IdExamen");
                    table.ForeignKey(
                        name: "FK_ReactivoDet_Reactivo_IdReactivo",
                        column: x => x.IdReactivo,
                        principalSchema: "crca",
                        principalTable: "Reactivo",
                        principalColumn: "IdReactivo");
                });

            migrationBuilder.CreateTable(
                name: "SistemaClienteExamen",
                schema: "conf",
                columns: table => new
                {
                    IdSistemaClienteExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdSistemaCliente = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IdExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CodRecibe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CodDevuelve = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SistemaClienteExamen", x => x.IdSistemaClienteExamen);
                    table.ForeignKey(
                        name: "FK_SistemaClienteExamen_Examen_IdExamen",
                        column: x => x.IdExamen,
                        principalSchema: "conf",
                        principalTable: "Examen",
                        principalColumn: "IdExamen");
                    table.ForeignKey(
                        name: "FK_SistemaClienteExamen_SistemaCliente_IdSistemaCliente",
                        column: x => x.IdSistemaCliente,
                        principalSchema: "conf",
                        principalTable: "SistemaCliente",
                        principalColumn: "IdSistemaCliente");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRolPermiso",
                schema: "segu",
                columns: table => new
                {
                    IdUsuarioRolPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuarioRol = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    IdPermiso = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRolPermiso", x => x.IdUsuarioRolPermiso);
                    table.ForeignKey(
                        name: "FK_UsuarioRolPermiso_Permiso_IdPermiso",
                        column: x => x.IdPermiso,
                        principalSchema: "segu",
                        principalTable: "Permiso",
                        principalColumn: "IdPermiso");
                    table.ForeignKey(
                        name: "FK_UsuarioRolPermiso_UsuarioRol_IdUsuarioRol",
                        column: x => x.IdUsuarioRol,
                        principalSchema: "segu",
                        principalTable: "UsuarioRol",
                        principalColumn: "IdUsuarioRol");
                });

            migrationBuilder.CreateTable(
                name: "ReactivoExamen",
                schema: "crca",
                columns: table => new
                {
                    IdReactivoExamen = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IdReactivoDet = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    IdExamen = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Creado_por = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Fecha_creacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modificado_por = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fecha_modificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactivoExamen", x => x.IdReactivoExamen);
                    table.ForeignKey(
                        name: "FK_ReactivoExamen_Examen_IdExamen",
                        column: x => x.IdExamen,
                        principalSchema: "conf",
                        principalTable: "Examen",
                        principalColumn: "IdExamen");
                    table.ForeignKey(
                        name: "FK_ReactivoExamen_ReactivoDet_IdReactivoDet",
                        column: x => x.IdReactivoDet,
                        principalSchema: "crca",
                        principalTable: "ReactivoDet",
                        principalColumn: "IdReactivoDet");
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "EquipoMedico",
                columns: new[] { "IdEquipoMedico", "Accion", "Creado_por", "Detalle", "Estado", "Fecha_creacion", "Fecha_modificacion", "IdArea", "IdLaboratorio", "Modificado_por", "Nombre" },
                values: new object[,]
                {
                    { "01EGBRJZVLYHXWPQ11MLUN2FKSA", "CREA", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(4106), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFVGC0DHKS5CQ5SCZCQT4VW", null, "RUBI" },
                    { "01JQWFHZRYGECUOX11TFZA2SPVK", "CREA", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(4104), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFVGC0DHKS5CQ5SCZCQT4VW", null, "ACL TOP 350" },
                    { "01WYEQHZDTNMSLJG11FKAV2RIUB", "CREA", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(4107), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFVGC0DHKS5CQ5SCZCQT4VW", null, "SELECTRA" },
                    { "01YTXUWJQVCSZLBN11ZGNH2DREA", "CREA", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(4099), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFVGC0DHKS5CQ5SCZCQT4VW", null, "ARCHITEC" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Laboratorio",
                columns: new[] { "IdLaboratorio", "Accion", "CodigoLaboratorio", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "Modificado_por", "Nombre" },
                values: new object[,]
                {
                    { "01HTFVGC0DHKS5CQ5SCZCQT4VW", "CREA", "01", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2787), null, null, "LABORATORIO CENTRAL" },
                    { "01HTFVGP4AXQY2G451F7Q8RTXY", "CREA", "02", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2790), null, null, "LABORATORIO EMERGENCIA" }
                });

            migrationBuilder.InsertData(
                schema: "segu",
                table: "Navbar",
                columns: new[] { "IdNavbar", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "Label", "Modificado_por", "TipoMenu", "icon", "routerlink" },
                values: new object[,]
                {
                    { 1, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2308), null, "INICIO", null, "0", "faHouse", "" },
                    { 2, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2311), null, "Dashboard", null, "1", "faChartColumn", "/inicio" },
                    { 3, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2313), null, "LABORATORIO", null, "0", "faFlaskVial", "" },
                    { 4, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2315), null, "Ordenes", null, "1", "faBarcode", "/laboratorio/orden" },
                    { 5, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2318), null, "Médico", null, "1", "faUserDoctor", "/laboratorio/medico" },
                    { 6, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2320), null, "Origen", null, "1", "faBuilding", "/laboratorio/origen" },
                    { 7, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2322), null, "Procedencia", null, "1", "faHospital", "/laboratorio/procedencia" },
                    { 8, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2327), null, "Servicio", null, "1", "faHouseMedical", "/laboratorio/servicio" },
                    { 9, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2329), null, "TRACKING", null, "0", "faFlaskVial", "" },
                    { 10, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2331), null, "Tracking", null, "1", "faChartColumn", "/tracking" },
                    { 11, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2333), null, "CONTROL CALIDAD", null, "0", "faHouse", "" },
                    { 12, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2335), null, "Configuracion", null, "1", "faChartColumn", "/controlcalidad/configuracion" },
                    { 13, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2337), null, "Resultado", null, "1", "faChartColumn", "/controlcalidad/resultado" },
                    { 14, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2340), null, "REPORTES", null, "0", "faChartColumn", "" },
                    { 15, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2341), null, "Orden de Paciente", null, "1", "faFileExcel", "/reporte/ordenporpaciente" },
                    { 16, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2343), null, "Resultado de Paciente", null, "1", "faFileExcel", "/reporte/resultadopaciente" },
                    { 17, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2345), null, "SEGURIDAD", null, "0", "faShield", "" },
                    { 18, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2347), null, "Usuario", null, "1", "faUserNurse", "/seguridad/usuario" },
                    { 19, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2349), null, "Rol", null, "1", "faIdCard", "/seguridad/rol" },
                    { 20, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2351), null, "CONFIGURACION", null, "0", "faGear", "" },
                    { 21, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2354), null, "Hospital", null, "1", "faHospital", "/configuracion/hospital" },
                    { 22, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2357), null, "Laboratorio", null, "1", "faFlaskVial", "/configuracion/laboratorio" },
                    { 23, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2358), null, "Areas", null, "1", "faLayerGroup", "/configuracion/area" },
                    { 24, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2360), null, "Tipo de muestras", null, "1", "faVial", "/configuracion/tipomuestra" },
                    { 25, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2363), null, "Examenes", null, "1", "faBiohazard", "/configuracion/examenes" },
                    { 26, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2365), null, "Equipos Medicos", null, "1", "faLaptopMedical", "/configuracion/equipomedico" },
                    { 27, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2367), null, "Sistema Externos", null, "1", "faLaptopCode", "/configuracion/sistemasexterno" },
                    { 28, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2372), null, "Maestras", null, "1", "faDatabase", "/configuracion/maestro" },
                    { 29, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2373), null, "Perfiles", null, "1", "faFileZipper", "/configuracion/perfiles" }
                });

            migrationBuilder.InsertData(
                schema: "labo",
                table: "Origen",
                columns: new[] { "IdOrigen", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "Modificado_por", "Nombre" },
                values: new object[,]
                {
                    { "01HTFSVFDEHJKTQAWGW634W6AA", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2202), null, null, "Areas Aministrativas" },
                    { "01HTFSVFDEHJKTQAWGW634W6AB", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2204), null, null, "Ayuda al diagnóstico" },
                    { "01HTFSVFDEHJKTQAWGW634W6AC", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2205), null, null, "Centro obstétrico" },
                    { "01HTFSVFDEHJKTQAWGW634W6AD", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2209), null, null, "Centro quirurgico" },
                    { "01HTFSVFDEHJKTQAWGW634W6AE", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2211), null, null, "Consultorio externo" },
                    { "01HTFSVFDEHJKTQAWGW634W6AF", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2212), null, null, "Emergencia" },
                    { "01HTFSVFDEHJKTQAWGW634W6AG", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2215), null, null, "Hospitalización" },
                    { "01HTFSVFDEHJKTQAWGW634W6AH", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2217), null, null, "Hospitalizacion Ambulatoria" },
                    { "01HTFSVFDEHJKTQAWGW634W6AI", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2218), null, null, "Unidad de Cuidadanos intensivos" },
                    { "01HTFSVFDEHJKTQAWGW634W6AJ", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2219), null, null, "Unidad de Cuidados intermedios" },
                    { "01HTFSVFDEHJKTQAWGW634W6AK", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2221), null, null, "Unidad de Vigilancia intensiva" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Perfil",
                columns: new[] { "IdPerfil", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "Modificado_por", "Nombre" },
                values: new object[,]
                {
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXV1", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(4143), null, null, "PERFIL OPERATORIO" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXV2", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(4146), null, null, "PERFIL LIPIDICO" }
                });

            migrationBuilder.InsertData(
                schema: "segu",
                table: "Permiso",
                columns: new[] { "IdPermiso", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "Modificado_por", "Nombre" },
                values: new object[,]
                {
                    { "BBHTFWGNWFAER1ZK118RZP3FHA", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3104), null, null, "CREATE" },
                    { "BBHTFWGNWFAER1ZK118RZP3FHB", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3106), null, null, "READ" },
                    { "BBHTFWGNWFAER1ZK118RZP3FHC", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3108), null, null, "UPDATE" },
                    { "BBHTFWGNWFAER1ZK118RZP3FHD", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3109), null, null, "DELETE" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Persona",
                columns: new[] { "IdPersona", "Accion", "ApeMaterno", "ApePaterno", "Creado_por", "Estado", "FechaNacimiento", "Fecha_creacion", "Fecha_modificacion", "IdSexo", "IdTipoDocu", "Modificado_por", "Nombre", "NroDocumento" },
                values: new object[,]
                {
                    { "01HTFSVCJC0PFRQAWGW634W656", "CREA", "Herrera", "Ramírez ", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1495), null, "MASC", "DNI", null, "Pedro Javier", "45036147" },
                    { "01HTFSVCJC0PFRQAWGW634W66T", "CREA", "Castro", "Reyes", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1527), null, "FEME", "DNI", null, "Carmen Teresa", "45036151" },
                    { "01HTFSVCJC0PFRQAWGW634W6GF", "CREA", "Torres", "Martínez ", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1471), null, "FEME", "DNI", null, "Laura Sofía", "45036144" },
                    { "01HTFSVCJC0PFRQAWGW634W6HG", "CREA", "López", "Ruiz", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1480), null, "MASC", "DNI", null, "José Antonio", "45036145" },
                    { "01HTFSVCJC0PFRQAWGW634W6JH", "CREA", "Reyes", "Herrera", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1512), null, "MASC", "DNI", null, "Miguel Ángel", "45036149" },
                    { "01HTFSVCJC0PFRQAWGW634W6JR", "CREA", "Torres", "Morales", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1504), null, "FEME", "DNI", null, "Lucía Alejandra", "45036148" },
                    { "01HTFSVCJC0PFRQAWGW634W6KJ", "CREA", "Ortiz", "García ", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1487), null, "FEME", "DNI", null, "Marta Elena", "45036146" },
                    { "01HTFSVCJC0PFRQAWGW634W6KY", "CREA", "Vargas", "Morales", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1518), null, "MASC", "DNI", null, "Antonio David", "45036150" },
                    { "01HTFSVCJC0PFRQAWGW634W6XM", "CREA", "ADMIN", "ADMIN", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1417), null, "MASC", "DNI", null, "ADMIN", "45036140" },
                    { "01HTFSVCJC0PFRQAWGW634W6XN", "CREA", "López", "Pérez", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1447), null, "MASC", "DNI", null, "Juan Carlos", "45036141" },
                    { "01HTFSVCJC0PFRQAWGW634W6XO", "CREA", "García", "Sánchez", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1455), null, "MASC", "DNI", null, "Carlos Alberto", "45036142" },
                    { "01HTFSVCJC0PFRQAWGW634W6XP", "CREA", "Martínez", "Gómez", "ADMIN", "ACTI", new DateTime(1988, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(1462), null, "FEME", "DNI", null, "Ana María", "45036143" }
                });

            migrationBuilder.InsertData(
                schema: "labo",
                table: "Procedencia",
                columns: new[] { "IdProcedencia", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "Modificado_por", "Nombre" },
                values: new object[,]
                {
                    { "01HTFSVCGDEAFRQAWGW634W6AA", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2118), null, null, "Emergencia" },
                    { "01HTFSVCGDEAFRQAWGW634W6AB", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2120), null, null, "Hospital Nacional Edgardo Rebagliati Martins" },
                    { "01HTFSVCGDEAFRQAWGW634W6AC", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2122), null, null, "Hospital Nacional Guillermo Almenara Irigoyen" },
                    { "01HTFSVCGDEAFRQAWGW634W6AD", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2123), null, null, "Hospital Nacional Dos de Mayo" },
                    { "01HTFSVCGDEAFRQAWGW634W6AE", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2125), null, null, "Instituto Nacional de Enfermedades Neoplásicas" },
                    { "01HTFSVCGDEAFRQAWGW634W6AF", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2126), null, null, "Hospital Nacional Arzobispo Loayza" },
                    { "01HTFSVCGDEAFRQAWGW634W6AG", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2128), null, null, "Hospital Nacional Cayetano Heredia" },
                    { "01HTFSVCGDEAFRQAWGW634W6AH", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2129), null, null, "Hospital Nacional Hipólito Unanue" },
                    { "01HTFSVCGDEAFRQAWGW634W6AI", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2131), null, null, "Hospital Regional Docente de Trujillo" },
                    { "01HTFSVCGDEAFRQAWGW634W6AJ", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2133), null, null, "Hospital Regional de Lambayeque" },
                    { "01HTFSVCGDEAFRQAWGW634W6AK", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2134), null, null, "Hospital Antonio Lorena" },
                    { "01HTFSVCGDEAFRQAWGW634W6AL", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2136), null, null, "Hospital Regional Honorio Delgado Espinoza" },
                    { "01HTFSVCGDEAFRQAWGW634W6AM", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2152), null, null, "Hospital Alberto Sabogal Sologuren" },
                    { "01HTFSVCGDEAFRQAWGW634W6AN", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2154), null, null, "Hospital de Emergencias Grau" },
                    { "01HTFSVCGDEAFRQAWGW634W6AO", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2155), null, null, "Hospital de Emergencias Pediátricas" },
                    { "01HTFSVCGDEAFRQAWGW634W6AP", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2157), null, null, "Hospital María Auxiliadora" }
                });

            migrationBuilder.InsertData(
                schema: "segu",
                table: "Rol",
                columns: new[] { "IdRol", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "Modificado_por", "Nombre" },
                values: new object[,]
                {
                    { "01HTFTW32KEH24P284SNVH8QPD", "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2562), null, null, "SuperAdmin" },
                    { "01HTFTWFZ6KMPARYMV6RKBBKTG", "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2566), null, null, "Doctor" },
                    { "01HTFTWTN8QAZRPG0GCVGXE05G", "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2568), null, null, "Licenciado" },
                    { "01HTFTX9W014EMBQDBAMDTZVN9", "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2569), null, null, "Tecnico" },
                    { "01HTFTXWJKVS3CN09Y479MG23C", "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2571), null, null, "Digitador" },
                    { "01HTFTXWJKVS3CN09Y479MG23D", "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2574), null, null, "ClienteLab" }
                });

            migrationBuilder.InsertData(
                schema: "labo",
                table: "Servicio",
                columns: new[] { "IdServicio", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "Modificado_por", "Nombre" },
                values: new object[,]
                {
                    { "01HTFSVCGDEAFRQAWGW634W6AA", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2044), null, null, "Patología" },
                    { "01HTFSVCGDEAFRQAWGW634W6AB", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2045), null, null, "Infectología" },
                    { "01HTFSVCGDEAFRQAWGW634W6AC", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2048), null, null, "Neurocirugía" },
                    { "01HTFSVCGDEAFRQAWGW634W6AD", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2050), null, null, "Osteopatía" },
                    { "01HTFSVCGDEAFRQAWGW634W6AE", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2051), null, null, "Odontología" },
                    { "01HTFSVCGDEAFRQAWGW634W6AF", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2053), null, null, "Toxicología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XA", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2003), null, null, "Emergencias" },
                    { "01HTFSVCGDEAFRQAWGW634W6XB", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2008), null, null, "Medicina Interna" },
                    { "01HTFSVCGDEAFRQAWGW634W6XC", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2010), null, null, "Pediatría" },
                    { "01HTFSVCGDEAFRQAWGW634W6XD", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2012), null, null, "Ginecología y Obstetricia" },
                    { "01HTFSVCGDEAFRQAWGW634W6XE", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2013), null, null, "Cardiología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XF", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2014), null, null, "Neumología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XG", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2016), null, null, "Neurología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XH", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2017), null, null, "Cirugía General" },
                    { "01HTFSVCGDEAFRQAWGW634W6XI", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2019), null, null, "Traumatología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XJ", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2020), null, null, "Urología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XK", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2021), null, null, "Gastroenterología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XL", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2023), null, null, "Nefrología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XM", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2024), null, null, "Hematología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XN", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2026), null, null, "Oncología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XO", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2028), null, null, "Dermatología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XP", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2030), null, null, "Endocrinología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XQ", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2031), null, null, "Psiquiatría" },
                    { "01HTFSVCGDEAFRQAWGW634W6XS", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2033), null, null, "Radiología e Imagenología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XT", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2034), null, null, "Laboratorio Clínico" },
                    { "01HTFSVCGDEAFRQAWGW634W6XU", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2035), null, null, "Anestesiología" },
                    { "01HTFSVCGDEAFRQAWGW634W6XV", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2037), null, null, "Medicina Nuclear" },
                    { "01HTFSVCGDEAFRQAWGW634W6XW", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2038), null, null, "Terapia Intensiva Neonatal" },
                    { "01HTFSVCGDEAFRQAWGW634W6XX", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2040), null, null, "Farmacia" },
                    { "01HTFSVCGDEAFRQAWGW634W6XY", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2041), null, null, "Servicios de Nutrición" },
                    { "01HTFSVCGDEAFRQAWGW634W6XZ", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2043), null, null, "Banco de Sangre" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "TablaMaestra",
                columns: new[] { "IdTablaMaestra", "Accion", "Codigo", "Color", "Creado_por", "Fecha_creacion", "Fecha_modificacion", "Modificado_por", "Nombre", "Tabla" },
                values: new object[,]
                {
                    { 1, "CREA", "ACTI", "qualified", "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2882), null, null, "ACTIVO", "States" },
                    { 2, "CREA", "DESA", "unqualified", "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2887), null, null, "DESACTIVADO", "States" },
                    { 3, "CREA", "ELIM", "unqualified", "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2889), null, null, "ELIMINADO", "States" },
                    { 4, "CREA", "CREA", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2891), null, null, "CREADO", "Actions" },
                    { 5, "CREA", "MODI", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2893), null, null, "MODIFICADO", "Actions" },
                    { 6, "CREA", "ELIM", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2895), null, null, "ELIMINADO", "Actions" },
                    { 7, "CREA", "AMBO", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2897), null, null, "AMBOS", "Sexo" },
                    { 8, "CREA", "MASC", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2901), null, null, "MASCULINO", "Sexo" },
                    { 9, "CREA", "FEME", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2902), null, null, "FEMENINO", "Sexo" },
                    { 10, "CREA", "DNI", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2904), null, null, "DNI", "TipoDocumento" },
                    { 11, "CREA", "ORDE", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2905), null, null, "POR ORDEN", "TipoOrden" },
                    { 12, "CREA", "EXAM", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2907), null, null, "POR EXAMEN", "TipoOrden" },
                    { 13, "CREA", "TODO", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2908), null, null, "TODOS", "EstadoOrden" },
                    { 14, "CREA", "PEND", "proposal", "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2910), null, null, "PENDIENTE", "EstadoOrden" },
                    { 15, "CREA", "PVAL", "new", "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2912), null, null, "POR VALIDAR", "EstadoOrden" },
                    { 16, "CREA", "VALI", "qualified", "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2922), null, null, "VALIDADO", "EstadoOrden" },
                    { 17, "CREA", "NORE", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2924), null, null, "NO REACTIVO", "Interpretado" },
                    { 18, "CREA", "INDE", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2926), null, null, "INDETERMINADO", "Interpretado" },
                    { 19, "CREA", "REAC", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2927), null, null, "REACTIVO", "Interpretado" },
                    { 20, "CREA", "SQL", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2929), null, null, "SQL SERVER", "TipoBaseDato" },
                    { 21, "CREA", "MYSQ", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2932), null, null, "MY SQL", "TipoBaseDato" },
                    { 22, "CREA", "POST", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2933), null, null, "POSTGREST", "TipoBaseDato" },
                    { 23, "CREA", "<", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2935), null, null, "<", "SignoComparativo" },
                    { 24, "CREA", ">", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2936), null, null, ">", "SignoComparativo" },
                    { 25, "CREA", "=", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2938), null, null, "=", "SignoComparativo" },
                    { 26, "CREA", ">=", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2939), null, null, ">=", "SignoComparativo" },
                    { 27, "CREA", "<=", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2941), null, null, "<=", "SignoComparativo" },
                    { 28, "CREA", "SEXO", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2942), null, null, "SEXO", "TipoConfRango" },
                    { 29, "CREA", "INT1", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2944), null, null, "INTERPRETADO 1", "TipoConfRango" },
                    { 30, "CREA", "INT2", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2945), null, null, "INTERPRETADO 2", "TipoConfRango" },
                    { 31, "CREA", "POS", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2947), null, null, "POSITIVO", "Interpretado2" },
                    { 32, "CREA", "IND", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2948), null, null, "INDETERMINADO", "Interpretado2" },
                    { 33, "CREA", "NEG", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2950), null, null, "NEGATIVO", "Interpretado2" },
                    { 34, "CREA", "0001", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2952), null, null, "INICIO", "Tracking" },
                    { 35, "CREA", "0002", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2954), null, null, "LECTURA DE ETIQUETA", "Tracking" },
                    { 36, "CREA", "0003", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2956), null, null, "ENVIO DE RESULTADOS", "Tracking" },
                    { 37, "CREA", "0004", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2957), null, null, "PREVALIDACION", "Tracking" },
                    { 38, "CREA", "0005", null, "FCONDOR", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2959), null, null, "VALIDACION", "Tracking" },
                    { 39, "CREA", "PEXA", null, "FCONDOR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "POR EXAMEN", "Modo" },
                    { 40, "CREA", "GEXA", null, "FCONDOR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "POR CONTROL", "Modo" },
                    { 41, "CREA", "INT3", null, "FCONDOR", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "RANGO NUMERICO", "TipoConfRango" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "TipoMuestra",
                columns: new[] { "IdTipoMuestra", "Accion", "CodigoTipoMuestra", "Creado_por", "Descripcion", "Estado", "Fecha_creacion", "Fecha_modificacion", "Modificado_por", "Nombre" },
                values: new object[,]
                {
                    { "01HTFRGNWFAERDZK11DRZP3FKSB", "CREA", "02", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3233), null, null, "PLASMA" },
                    { "01HTFRGNWFAERDZK11DRZP3FKSF", "CREA", "05", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3240), null, null, "ACIDO NUCLEICO" },
                    { "01HTFRGNWFAERDZK11DRZP3FWEA", "CREA", "01", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3231), null, null, "SANGRE TOTAL" },
                    { "01HTFRGNWFAERDZK11DRZP3FWEE", "CREA", "05", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3238), null, null, "SEMEN" },
                    { "01HTFRGNWFAERDZK11DRZP3LKCC", "CREA", "03", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3235), null, null, "ORINA" },
                    { "01HTFRGNWFAERDZK11DRZP3LKCH", "CREA", "09", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3244), null, null, "CARRILLO BUCAL" },
                    { "01HTFRGNWFAERDZK11DRZP3LKCI", "CREA", "10", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3245), null, null, "LIQUIDO" },
                    { "01HTFRGNWFAERDZK11DRZP3LKCJ", "CREA", "11", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3247), null, null, "ESPUTO" },
                    { "01HTFRGNWFAERDZK11DRZP3LKCK", "CREA", "12", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3249), null, null, "HECES" },
                    { "01HTFRGNWFAERDZK11DRZP3LKCL", "CREA", "13", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3250), null, null, "MUESTRA DERMICA" },
                    { "01HTFRGNWFAERDZK11DRZP3LKCM", "CREA", "14", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3252), null, null, "SECRECION URETRAL" },
                    { "01HTFRGNWFAERDZK11DRZP3LKCN", "CREA", "15", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3253), null, null, "SECRECION VAGINAL" },
                    { "01HTFRGNWFAERDZK11DRZP3LKCO", "CREA", "16", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3255), null, null, "SECRECION FARINGEA" },
                    { "01HTFRGNWFAERDZK11DRZP3LMFD", "CREA", "04", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3236), null, null, "SUERO" },
                    { "01HTFRGNWFAERDZK11DRZP3LMFG", "CREA", "08", "ADMIN", null, "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3242), null, null, "MEDULA OSEA" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Area",
                columns: new[] { "IdArea", "Accion", "Creado_por", "Descripcion", "Estado", "Fecha_creacion", "Fecha_modificacion", "IdLaboratorio", "Modificado_por", "Nombre" },
                values: new object[,]
                {
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "CREA", "CADC", "", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2826), null, "01HTFVGC0DHKS5CQ5SCZCQT4VW", null, "BIOQUÍMICA" },
                    { "01HTFVCPCMG5V1MNCQ5XWG1CVV", "CREA", "CADC", "", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2830), null, "01HTFVGC0DHKS5CQ5SCZCQT4VW", null, "ENDOCRINOLOGIA" },
                    { "01HTFVD0AKYV3AHTSPN1VJAECK", "CREA", "CADC", "", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2833), null, "01HTFVGC0DHKS5CQ5SCZCQT4VW", null, "HEMATOLOGIA" },
                    { "01HTFVDD2K6YF7AVR247GRWSDE", "CREA", "CADC", "", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2837), null, "01HTFVGC0DHKS5CQ5SCZCQT4VW", null, "INMUNOLOGIA" },
                    { "01HTFVDD2K6YF7AVR247HRDGDB", "CREA", "CADC", "", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2841), null, "01HTFVGC0DHKS5CQ5SCZCQT4VW", null, "MICROBIOLOGIA" },
                    { "01HTFVDD2K6YF7AVR247NTDSWR", "CREA", "CADC", "", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2839), null, "01HTFVGC0DHKS5CQ5SCZCQT4VW", null, "MARCADORES TUMORALES" },
                    { "01HTFVDD2K6YF7AVR247SDFSDF", "CREA", "CADC", "", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2834), null, "01HTFVGC0DHKS5CQ5SCZCQT4VW", null, "HEPATITIS" },
                    { "01HTFVDVESJX8XN6H29Z3WVN9M", "CREA", "CADC", "", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2842), null, "01HTFVGP4AXQY2G451F7Q8RTXY", null, "EMERGENCIA" }
                });

            migrationBuilder.InsertData(
                schema: "labo",
                table: "Medico",
                columns: new[] { "IdMedico", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "IdPersona", "Modificado_por" },
                values: new object[,]
                {
                    { "01HTFSVCJC0PFRDE3RF5H4W6XA", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2263), null, "01HTFSVCJC0PFRQAWGW634W6XN", null },
                    { "01HTFSVCJC0PFRDE3RF5H4W6XB", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2265), null, "01HTFSVCJC0PFRQAWGW634W6XO", null },
                    { "01HTFSVCJC0PFRDE3RF5H4W6XC", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2267), null, "01HTFSVCJC0PFRQAWGW634W6XP", null }
                });

            migrationBuilder.InsertData(
                schema: "segu",
                table: "NavbarRelacion",
                columns: new[] { "IdNavbarRelacion", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "IdNavbarPrincipal", "IdNavbarSecundario", "Modificado_por" },
                values: new object[,]
                {
                    { 1, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2423), null, 1, 2, null },
                    { 2, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2475), null, 3, 4, null },
                    { 3, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2478), null, 3, 5, null },
                    { 4, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2480), null, 3, 6, null },
                    { 5, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2481), null, 3, 7, null },
                    { 6, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2485), null, 3, 8, null },
                    { 7, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2486), null, 9, 10, null },
                    { 9, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2488), null, 11, 12, null },
                    { 10, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2490), null, 11, 13, null },
                    { 11, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2492), null, 14, 15, null },
                    { 12, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2494), null, 14, 16, null },
                    { 13, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2496), null, 17, 18, null },
                    { 14, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2498), null, 17, 19, null },
                    { 16, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2500), null, 20, 21, null },
                    { 17, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2502), null, 20, 22, null },
                    { 18, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2504), null, 20, 23, null },
                    { 19, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2506), null, 20, 24, null },
                    { 20, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2508), null, 20, 25, null },
                    { 21, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2510), null, 20, 26, null },
                    { 22, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2512), null, 20, 27, null },
                    { 23, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2514), null, 20, 28, null },
                    { 24, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2516), null, 20, 29, null }
                });

            migrationBuilder.InsertData(
                schema: "segu",
                table: "NavbarRelacionRol",
                columns: new[] { "IdNavbarRelacionRol", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "IdNavbarRelacion", "IdRol", "Modificado_por", "navbarRelacionIdNavbarRelacion" },
                values: new object[,]
                {
                    { 1, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2607), null, 1, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 2, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2610), null, 2, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 3, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2612), null, 3, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 4, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2613), null, 4, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 5, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2615), null, 5, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 6, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2617), null, 6, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 7, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2618), null, 7, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 8, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2620), null, 8, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 9, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2621), null, 9, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 10, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2624), null, 10, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 11, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2625), null, 11, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 12, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2627), null, 12, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 13, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2629), null, 13, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 14, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2630), null, 14, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 15, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2633), null, 15, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 16, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2634), null, 16, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 17, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2636), null, 17, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 18, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2637), null, 18, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 19, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2640), null, 19, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 20, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2641), null, 20, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 21, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2643), null, 21, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 22, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2650), null, 22, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 23, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2652), null, 23, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 24, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2653), null, 24, "01HTFTW32KEH24P284SNVH8QPD", null, null },
                    { 25, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2656), null, 1, "01HTFTWFZ6KMPARYMV6RKBBKTG", null, null },
                    { 26, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2658), null, 2, "01HTFTWFZ6KMPARYMV6RKBBKTG", null, null },
                    { 27, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2659), null, 3, "01HTFTWFZ6KMPARYMV6RKBBKTG", null, null },
                    { 28, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2668), null, 4, "01HTFTWFZ6KMPARYMV6RKBBKTG", null, null },
                    { 29, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2670), null, 5, "01HTFTWFZ6KMPARYMV6RKBBKTG", null, null },
                    { 30, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2671), null, 6, "01HTFTWFZ6KMPARYMV6RKBBKTG", null, null },
                    { 31, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2673), null, 7, "01HTFTWFZ6KMPARYMV6RKBBKTG", null, null },
                    { 32, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2684), null, 8, "01HTFTWFZ6KMPARYMV6RKBBKTG", null, null },
                    { 33, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2686), null, 9, "01HTFTWFZ6KMPARYMV6RKBBKTG", null, null },
                    { 34, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2687), null, 10, "01HTFTWFZ6KMPARYMV6RKBBKTG", null, null },
                    { 35, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2689), null, 1, "01HTFTWTN8QAZRPG0GCVGXE05G", null, null },
                    { 36, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2690), null, 2, "01HTFTWTN8QAZRPG0GCVGXE05G", null, null },
                    { 37, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2692), null, 10, "01HTFTWTN8QAZRPG0GCVGXE05G", null, null },
                    { 38, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2694), null, 1, "01HTFTX9W014EMBQDBAMDTZVN9", null, null },
                    { 39, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2696), null, 10, "01HTFTX9W014EMBQDBAMDTZVN9", null, null },
                    { 40, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2697), null, 1, "01HTFTXWJKVS3CN09Y479MG23C", null, null },
                    { 41, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2699), null, 2, "01HTFTXWJKVS3CN09Y479MG23C", null, null },
                    { 42, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2700), null, 2, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 43, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2702), null, 3, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 44, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2704), null, 4, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 45, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2705), null, 5, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 46, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2707), null, 6, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 47, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2708), null, 7, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 48, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2710), null, 11, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 49, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2711), null, 12, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 50, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2713), null, 15, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 51, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2716), null, 16, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 52, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2718), null, 17, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 53, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2720), null, 18, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 54, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2722), null, 19, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 55, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2724), null, 20, "01HTFTXWJKVS3CN09Y479MG23D", null, null },
                    { 56, "CREA", "CADC", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(2725), null, 24, "01HTFTXWJKVS3CN09Y479MG23D", null, null }
                });

            migrationBuilder.InsertData(
                schema: "segu",
                table: "Usuario",
                columns: new[] { "IdUsuario", "Accion", "CodExterno", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "IdPersona", "Modificado_por", "Password", "Permiso_Escritura", "Primer_acceso", "UserName" },
                values: new object[,]
                {
                    { "01HTFSTS3J5AETX0AK92VB9F3D", "CREA", "", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3029), null, "01HTFSVCJC0PFRQAWGW634W6XN", null, "Yt6ay0mRsy2nl70yCdcRGg==", true, (byte)0, "USER1" },
                    { "01HTFSTS3J5AETX0AK92VB9F3E", "CREA", "", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3031), null, "01HTFSVCJC0PFRQAWGW634W6XO", null, "Yt6ay0mRsy2nl70yCdcRGg==", true, (byte)0, "USER2" },
                    { "01HTFSTS3J5AETX0AK92VB9F3F", "CREA", "", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3035), null, "01HTFSVCJC0PFRQAWGW634W6XP", null, "Yt6ay0mRsy2nl70yCdcRGg==", false, (byte)0, "USER3" },
                    { "01HTFSTS3J5AETX0AK92VB9F4D", "CREA", "", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3026), null, "01HTFSVCJC0PFRQAWGW634W6XM", null, "Yt6ay0mRsy2nl70yCdcRGg==", true, (byte)0, "ADMIN" }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "Examen",
                columns: new[] { "IdExamen", "Abreviatura", "Accion", "Calculado", "CantidadDecimal", "Color", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "IdArea", "IdTipoMuestra", "Modificado_por", "Nombre", "Orden", "RangoMostrar", "TiempoTrackingMin", "TipoCongRango", "UnidadMedida" },
                values: new object[,]
                {
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXA", "Sat. Transf.", "CREA", null, null, "#1d13da", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3475), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Saturación de Transferrina", null, null, 60, null, "%" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXA1", "Col. HDL", "CREA", null, null, "#1d13f1", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3541), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Colesterol HDL", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXA2", "LH", "CREA", null, null, "#1d1408", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3599), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "LH", null, null, 60, null, "mUI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXA3", "GS / Rh", "CREA", null, null, "#1d141f", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3669), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Grupo Sanguineo /Factor", null, null, 60, null, "Cualitativo " },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXA4", "RB", "CREA", null, null, "#1d1436", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3723), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Rosa de Bengala", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXA5", "FR-LAT", "CREA", null, null, "#1d144d", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3789), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Factor Reumatoideo Latex", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXA6", "PSA Total", "CREA", null, null, "#1d1464", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3853), null, "01HTFVDD2K6YF7AVR247NTDSWR", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "PSA Total", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXB", "Proteinograma", "CREA", null, null, "#1d13db", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3477), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Proteinograma Electroforético", null, null, 60, null, "g/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXB1", "Citoquímico", "CREA", null, null, "#1d13f2", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3543), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3LKCK", null, "Citoquímico de Líquido", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXB2", "Ins. Post", "CREA", null, null, "#1d1409", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3601), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Insulina Post Pandria!", null, null, 60, null, "µU/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXB3", "GOTA", "CREA", null, null, "#1d1420", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3671), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Gota gruesa", null, null, 60, null, "Positivo/Negativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXB4", "PCR-CUANT", "CREA", null, null, "#1d1437", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3737), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "PCR Cuantitativo", null, null, 60, null, "mg/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXB5", "FER", "CREA", null, null, "#1d144e", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3793), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Ferritina", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXB6", "PSA Libre", "CREA", null, null, "#1d1465", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3855), null, "01HTFVDD2K6YF7AVR247NTDSWR", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "PSA Libre", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXC", "Prot. Total", "CREA", null, null, "#1d13dc", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3480), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Proteinas Tot. y Frac.", null, null, 60, null, "g/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXC1", "Ca. Sérico", "CREA", null, null, "#1d13f3", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3545), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Calcio Sérico", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXC2", "Ins. Basal", "CREA", null, null, "#1d140a", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3603), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Insulina Basal", null, null, 60, null, "µU/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXC3", "FIB", "CREA", null, null, "#1d1421", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3674), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Fibrinógeno", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXC4", "PCR-CUAL", "CREA", null, null, "#1d1438", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3740), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "PCR Cualitativo", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXC5", "ESPER", "CREA", null, null, "#1d144f", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3795), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEE", null, "Espermatograma", null, null, 60, null, "Variado" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXC6", "Índice PSA", "CREA", null, null, "#1d1466", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3859), null, "01HTFVDD2K6YF7AVR247NTDSWR", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Indice de PSA", null, null, 60, null, "-" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXD", "Magnesio", "CREA", null, null, "#1d13dd", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3483), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Magnesio", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXD1", "Ca. 24h", "CREA", null, null, "#1d13f4", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3547), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3LKCC", null, "Calcio 24h.", null, null, 60, null, "mg/24h" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXD2", "GH", "CREA", null, null, "#1d140b", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3606), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Hormona de Crecimiento", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXD3", "COAG-S", "CREA", null, null, "#1d1422", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3676), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Coagulación y Sangria", null, null, 60, null, "Segundos" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXD4", "NTX", "CREA", null, null, "#1d1439", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3742), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3LKCC", null, "NTX", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXD5", "CMV-IgM", "CREA", null, null, "#1d1450", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3798), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Citomegalovirus IgM", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXD6", "CEA", "CREA", null, null, "#1d1467", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3861), null, "01HTFVDD2K6YF7AVR247NTDSWR", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "CEA (Ag. CArcinoembrionario)", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXE", "Lipasa", "CREA", null, null, "#1d13de", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3485), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Lipasa", null, null, 60, null, "U/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXE1", "BUN", "CREA", null, null, "#1d13f5", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3550), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Nitrógeno Ureico Sanguíneo", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXE2", "FSH", "CREA", null, null, "#1d140c", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3608), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "FSH", null, null, 60, null, "mUI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXE3", "CEL-LE", "CREA", null, null, "#1d1423", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3678), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Células LE", null, null, 60, null, "Positivo/Negativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXE4", "Inmuno-M", "CREA", null, null, "#1d143a", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3744), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Inmunoglobulina M", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXE5", "CMV-IgG", "CREA", null, null, "#1d1451", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3800), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Citomegalovirus IgG", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXE6", "CA 19-9", "CREA", null, null, "#1d1468", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3863), null, "01HTFVDD2K6YF7AVR247NTDSWR", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "CA 19-9 (Páncreas)", null, null, 60, null, "U/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXF", "LDH", "CREA", null, null, "#1d13df", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3487), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Deshidrogenasa Láctica", null, null, 60, null, "U/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXF1", "Bil. Total", "CREA", null, null, "#1d13f6", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3552), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Bilirrubina Total y Fracc.", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXF2", "E3 Total", "CREA", null, null, "#1d140d", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3610), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Estriol Total", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXF3", "CC", "CREA", null, null, "#1d1424", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3680), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Constantes Corpuscular", null, null, 60, null, "g/Dl" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXF4", "Inmuno-G", "CREA", null, null, "#1d143b", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3746), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Inmunoglobulina G", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXF5", "CHAG", "CREA", null, null, "#1d1452", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3802), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Chagas", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXF6", "CA 15-3", "CREA", null, null, "#1d1469", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3866), null, "01HTFVDD2K6YF7AVR247NTDSWR", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "CA 15-3 (Mama)", null, null, 60, null, "U/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXG", "HbA1c", "CREA", null, null, "#1d13e0", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3490), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Hemoglobina Glicosilada", null, null, 60, null, "%" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXG1", "Bil. Indirecta", "CREA", null, null, "#1d13f7", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3555), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Bilirrubina Indirecta", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXG2", "E3 Libre", "CREA", null, null, "#1d140e", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3613), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Estriol Libre", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXG3", "IgM Anti-HBc", "CREA", null, null, "#1d1425", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3683), null, "01HTFVDD2K6YF7AVR247SDFSDF", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Hepatitis B Core IgM", null, null, 60, null, "UI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXG4", "Inmuno-E", "CREA", null, null, "#1d143c", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3748), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Inmunoglobulina E", null, null, 60, null, "IU/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXG5", "C4", "CREA", null, null, "#1d1453", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3805), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "C4 (Complemento 4)", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXG6", "CA 125", "CREA", null, null, "#1d146a", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3868), null, "01HTFVDD2K6YF7AVR247NTDSWR", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "CA 125 (Ovario)", null, null, 60, null, "U/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXH", "Gluc. U.", "CREA", null, null, "#1d13e1", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3492), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3LKCC", null, "Glucosa en orina", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXH1", "Bil. Directa", "CREA", null, null, "#1d13f8", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3557), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Bilirrubina Directa", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXH2", "E2", "CREA", null, null, "#1d140f", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3615), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Estradiol", null, null, 60, null, "pg/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXH3", "IgM Anti-HAV", "CREA", null, null, "#1d1426", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3686), null, "01HTFVDD2K6YF7AVR247SDFSDF", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Hepatitis A IgM", null, null, 60, null, "UI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXH4", "Inmuno-A", "CREA", null, null, "#1d143d", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3751), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Inmunoglobulina A", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXH5", "C3", "CREA", null, null, "#1d1454", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3807), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "C3 (Complemento 3)", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXH6", "B2M", "CREA", null, null, "#1d146b", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3870), null, "01HTFVDD2K6YF7AVR247NTDSWR", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Beta-2 Microglobulina", null, null, 60, null, "mg/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXI", "Gluc. Post P.", "CREA", null, null, "#1d13e2", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3494), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Glucosa Post Prandial", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXI1", "AST", "CREA", null, null, "#1d13f9", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3559), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "TGO (Aspartato Amino Transterasa)", null, null, 60, null, "U/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXI2", "DHEAS", "CREA", null, null, "#1d1410", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3628), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "DHEAS", null, null, 60, null, "µg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXI3", "HBsAg", "CREA", null, null, "#1d1427", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3689), null, "01HTFVDD2K6YF7AVR247SDFSDF", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Hepatitis B Ag Superf. (HBsAg)", null, null, 60, null, "UI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXI4", "HV2-IgM", "CREA", null, null, "#1d143e", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3754), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Herpes Virus 2 lgM", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXI5", "BRU-PLA", "CREA", null, null, "#1d1455", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3809), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Brucella en Placa", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXI6", "AFP", "CREA", null, null, "#1d146c", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3874), null, "01HTFVDD2K6YF7AVR247NTDSWR", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Alla Feto Proteina", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXJ", "Gluc. Basal", "CREA", null, null, "#1d13e3", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3496), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Glucosa Basal", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXJ1", "Amilasa U. 24h", "CREA", null, null, "#1d13fa", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3561), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3LKCC", null, "Amilasa en Orina (24h)", null, null, 60, null, "U/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXJ2", "C. pm.", "CREA", null, null, "#1d1411", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3630), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Cortisol pm.", null, null, 60, null, "µg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXJ3", "Anti-HCV", "CREA", null, null, "#1d1428", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3691), null, "01HTFVDD2K6YF7AVR247SDFSDF", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Hepatitis C AntiHCB", null, null, 60, null, "UI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXJ4", "HV2-IgG", "CREA", null, null, "#1d143f", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3756), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Herpes Virus 2 lgG", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXJ5", "BRU-IgM", "CREA", null, null, "#1d1456", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3812), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Brucella IgM", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXJ6", "URO", "CREA", null, null, "#1d146d", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3876), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCC", null, "Urocultivo", null, null, 60, null, "UFC/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXK", "GGTF", "CREA", null, null, "#1d13e4", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3499), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "GGTF", null, null, 60, null, "U/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXK1", "Amilasa", "CREA", null, null, "#1d13fb", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3564), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Amilasa", null, null, 60, null, "U/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXK2", "C. am.", "CREA", null, null, "#1d1412", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3632), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Cortisol am.", null, null, 60, null, "µg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXK3", "Anti-HBc", "CREA", null, null, "#1d1429", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3693), null, "01HTFVDD2K6YF7AVR247SDFSDF", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Hepatitis B Anticore Total", null, null, 60, null, "UI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXK4", "HV1-IgM", "CREA", null, null, "#1d1440", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3758), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Herpes Virus 1 lgM", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXK5", "BRU-IgG", "CREA", null, null, "#1d1457", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3814), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Brucella IgG", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXK6", "HC", "CREA", null, null, "#1d146e", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3879), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Hemocultivo", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXL", "Fósforo U.", "CREA", null, null, "#1d13e5", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3502), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3LKCC", null, "Fósforo en Orina", null, null, 60, null, "mg/24h" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXL1", "ALT", "CREA", null, null, "#1d13fc", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3566), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "TGP (Alanino Amino Transferasa)", null, null, 60, null, "U/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXL2", "ACTH", "CREA", null, null, "#1d1413", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3634), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "ACTH", null, null, 60, null, "pg/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXL3", "Anti-HAV", "CREA", null, null, "#1d142a", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3696), null, "01HTFVDD2K6YF7AVR247SDFSDF", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Hepatitis A total", null, null, 60, null, "UI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXL4", "HV1-IgG", "CREA", null, null, "#1d1441", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3760), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Herpes Virus 1 lgG", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXL5", "AT+AP", "CREA", null, null, "#1d1458", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3817), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "(Antitiroglobulina + Antiperoxidasa)", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXL6", "BK-DIR-S", "CREA", null, null, "#1d146f", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3881), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCJ", null, "BK Directo Seriado", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXM", "Fósforo", "CREA", null, null, "#1d13e6", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3504), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Fósforo", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXM1", "Ác. Úrico", "CREA", null, null, "#1d13fd", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3569), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Ácido Urico", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXM2", "VSG-WG", "CREA", null, null, "#1d1414", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3637), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "VSG Westergree", null, null, 60, null, "mm/h" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXM3", "WR", "CREA", null, null, "#1d142b", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3698), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Waller Rose", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXM4", "HP-IgM", "CREA", null, null, "#1d1442", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3763), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Helicobacter Pylori IgM", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXM5", "ANCA", "CREA", null, null, "#1d1459", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3819), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "ANCA Antineutrófilos", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXM6", "BK-DIR", "CREA", null, null, "#1d1470", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3883), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCJ", null, "BK Directo l", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXN", "Fosf. Alcalina", "CREA", null, null, "#1d13e7", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3506), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Fosfatasa Alcalina", null, null, 60, null, "U/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXN1", "TSH U.", "CREA", null, null, "#1d13fe", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3572), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "TSH Ultrasensible", null, null, 60, null, "µUI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXN2", "VSG-W", "CREA", null, null, "#1d1415", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3639), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "VSG Wintrobe", null, null, 60, null, "mm/h" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXN3", "VIT-B12", "CREA", null, null, "#1d142c", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3700), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Vitamina B12", null, null, 60, null, "pg/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXN4", "HP-IgG", "CREA", null, null, "#1d1443", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3765), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Helicobacter Pylori IgG", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXN5", "AG-PLA", "CREA", null, null, "#1d145a", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3821), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Aglutinaciones en Placa", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXN6", "COPRO", "CREA", null, null, "#1d1471", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3885), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCK", null, "Coprocultivo", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXO", "Fe sérico", "CREA", null, null, "#1d13e8", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3517), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "+ Fe sérico", null, null, 60, null, "µg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXO1", "TSH", "CREA", null, null, "#1d13ff", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3574), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "TSH", null, null, 60, null, "µUI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXO2", "TTP", "CREA", null, null, "#1d1416", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3642), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "T. de tromboplastina Parcial", null, null, 60, null, "Segundos" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXO3", "VDRL", "CREA", null, null, "#1d142d", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3702), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "VDRL", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXO4", "HIV-WB", "CREA", null, null, "#1d1444", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3767), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "H.I.V. (Wester Blot)", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXO5", "A-DNA", "CREA", null, null, "#1d145b", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3823), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "AntiDNA Nativo", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXO6", "CH", "CREA", null, null, "#1d1472", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3888), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCL", null, "Cultivo de Hongos", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXP", "Fe sérico", "CREA", null, null, "#1d13e9", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3520), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Fierro (Hierro) Sérico", null, null, 60, null, "µg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXP1", "Test. Total", "CREA", null, null, "#1d1400", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3576), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Testosterona Total", null, null, 60, null, "ng/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXP2", "TT", "CREA", null, null, "#1d1417", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3644), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "T. de Trombina", null, null, 60, null, "Segundos" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXP3", "TROPO", "CREA", null, null, "#1d142e", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3705), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Troponina", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXP4", "HIV-RAP", "CREA", null, null, "#1d1445", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3770), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "H.I.V. (Prueba Rápida)", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXP5", "AC-SCUANT", "CREA", null, null, "#1d145c", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3825), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Antiestreptolisina Semicuant.", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXP6", "CSU", "CREA", null, null, "#1d1473", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3890), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCM", null, "Cultivo de Sec. Uretral", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXQ", "Examen Orina", "CREA", null, null, "#1d13ea", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3522), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3LKCC", null, "Examén de Orina", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXQ1", "Test. Libre", "CREA", null, null, "#1d1401", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3579), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Testosterona Libre", null, null, 60, null, "ng/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXQ2", "TPT / INR", "CREA", null, null, "#1d1418", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3646), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "T. de Protrombina / INR", null, null, 60, null, "Segundos / Ratio" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXQ3", "TOX-IgM", "CREA", null, null, "#1d142f", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3708), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Toxoplasma IgM", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXQ4", "HIV-I-II", "CREA", null, null, "#1d1446", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3773), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "H.I.V. I-II (Anti. Anticuerpo)", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXQ5", "AC-ML", "CREA", null, null, "#1d145d", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3827), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Antic Músculo Liso", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXQ6", "CSV", "CREA", null, null, "#1d1474", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3892), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCN", null, "Cultivo de Sec. Vaginal", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "Urea", "CREA", null, null, "#1d13d4", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3458), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Urea", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXR1", "Electrólitos", "CREA", null, null, "#1d13eb", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3527), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Electrólitos", null, null, 60, null, "mmol/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXR2", "T4", "CREA", null, null, "#1d1402", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3581), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "T4 Total", null, null, 60, null, "µg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXR3", "TCI", "CREA", null, null, "#1d1419", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3649), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Test Coombs Indirecto", null, null, 60, null, "Positivo/Negativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXR4", "TOX-IgG", "CREA", null, null, "#1d1430", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3710), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Toxoplasma IgG", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXR5", "HIDAT", "CREA", null, null, "#1d1447", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3776), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Hidatidosis (W.B.)", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXR6", "AC-FOL", "CREA", null, null, "#1d145e", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3830), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Acido fólico", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXR7", "CSF", "CREA", null, null, "#1d1475", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3894), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCO", null, "Cultivo Sec. Faringea", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXS", "TTOG", "CREA", null, null, "#1d13d5", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3464), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Test de tolerancia Glucosa", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXS1", "Creatinina", "CREA", null, null, "#1d13ec", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3529), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Creatinina", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXS2", "T3 Libre", "CREA", null, null, "#1d1403", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3583), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "T3 Libre", null, null, 60, null, "pg/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXS3", "TCD", "CREA", null, null, "#1d141a", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3652), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Test Coombs Directo", null, null, 60, null, "Positivo/Negativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXS4", "TORCH-IgM", "CREA", null, null, "#1d1431", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3712), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "TORCH IgM", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXS5", "HCG-CUANT", "CREA", null, null, "#1d1448", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3778), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "HCG Beta Cuantitativo", null, null, 60, null, "mUI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXS6", "AC-CUANT", "CREA", null, null, "#1d145f", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3843), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Antiestreptolisina Cuantit.", null, null, 60, null, "UI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXS7", "FD-H", "CREA", null, null, "#1d1476", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3897), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCL", null, "Frotis Directo (Hongos)", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXT", "TG", "CREA", null, null, "#1d13d6", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3466), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Triglicéridos", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXT1", "Creat. 24h", "CREA", null, null, "#1d13ed", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3532), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3LKCC", null, "Dep. de Creatinina 24h.", null, null, 60, null, "mg/24h" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXT2", "T3", "CREA", null, null, "#1d1404", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3585), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "T3 Total", null, null, 60, null, "ng/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXT3", "RET", "CREA", null, null, "#1d141b", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3656), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Reticulocitos", null, null, 60, null, "%" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXT4", "TORCH-IgG", "CREA", null, null, "#1d1432", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3714), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "TORCH IgG", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXT5", "HCG-CUAL", "CREA", null, null, "#1d1449", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3780), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "HCG Beta Cualitativo", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXT6", "AC-ANA", "CREA", null, null, "#1d1460", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3845), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Antic Antinucleares (ANA)", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXT7", "HKOH", "CREA", null, null, "#1d1477", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3899), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCL", null, "Hongos - KOH", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXU", "Test Tol L.", "CREA", null, null, "#1d13d7", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3468), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Test de tolerancia Lactosa", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXU1", "CPK Total", "CREA", null, null, "#1d13ee", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3534), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "CPK TOTAL", null, null, 60, null, "U/L" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXU2", "Prolactina", "CREA", null, null, "#1d1405", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3592), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Pool de Prolactina", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXU3", "L-PER", "CREA", null, null, "#1d141c", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3661), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Lámina Periférica", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXU4", "SET-BRUC", "CREA", null, null, "#1d1433", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3716), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Set de Brucela", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXU5", "FTA-PRU", "CREA", null, null, "#1d144a", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3782), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Prueba de FTA ABS", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXU6", "AC-AM", "CREA", null, null, "#1d1461", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3847), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Antic Antimitocondriales", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXU7", "R-ATB", "CREA", null, null, "#1d1478", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3901), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCC", null, "Removedor de ATB", null, null, 60, null, "UFC/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXV", "Test Ác. Úrico", "CREA", null, null, "#1d13d8", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3471), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Test de Ácido Urico", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXV1", "Col. Total", "CREA", null, null, "#1d13ef", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3537), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Colesterol Total", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXV2", "Prolactina", "CREA", null, null, "#1d1406", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3595), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Prolactina", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXV3", "HGB / HTO", "CREA", null, null, "#1d141d", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3664), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Hemoglobina/hto", null, null, 60, null, "g/dL / %" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXV4", "RUB-IgG", "CREA", null, null, "#1d1434", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3718), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Rubéola IgG o IgM", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXV5", "FTA", "CREA", null, null, "#1d144b", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3785), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "FTA ABS", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXV6", "AC-AC-IgM", "CREA", null, null, "#1d1462", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3849), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Antic Anticlamydia IgM", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXV7", "URO", "CREA", null, null, "#1d1479", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3903), null, "01HTFVDD2K6YF7AVR247HRDGDB", "01HTFRGNWFAERDZK11DRZP3LKCC", null, "Urocultivo con", null, null, 60, null, "UFC/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXW", "Sat. Transf.", "CREA", null, null, "#1d13d9", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3473), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "% de sat. de transferrina", null, null, 60, null, "%" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXW1", "Col. LDL", "CREA", null, null, "#1d13f0", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3539), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Colesterol LDL", null, null, 60, null, "mg/dL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXW2", "Progesterona", "CREA", null, null, "#1d1407", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3597), null, "01HTFVCPCMG5V1MNCQ5XWG1CVV", "01HTFRGNWFAERDZK11DRZP3LMFD", null, "Progesterona", null, null, 60, null, "ng/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXW3", "HEM-AUT", "CREA", null, null, "#1d141e", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3667), null, "01HTFVD0AKYV3AHTSPN1VJAECK", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Hemograma Automatizado", null, null, 60, null, "Cualitativo " },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXW4", "RPR", "CREA", null, null, "#1d1435", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3720), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "RPR", null, null, 60, null, "Cualitativo" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXW5", "FR-TURB", "CREA", null, null, "#1d144c", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3787), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Factor Reumatoideo Turb", null, null, 60, null, "UI/mL" },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXW6", "AC-AC-IgG", "CREA", null, null, "#1d1463", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3851), null, "01HTFVDD2K6YF7AVR247GRWSDE", "01HTFRGNWFAERDZK11DRZP3FWEA", null, "Antic Anticlamydia IgG", null, null, 60, null, "Cualitativo" }
                });

            migrationBuilder.InsertData(
                schema: "segu",
                table: "UsuarioArea",
                columns: new[] { "IdUsuarioArea", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "IdArea", "IdUsuario", "Modificado_por" },
                values: new object[,]
                {
                    { "01HTFWGNWFAER1ZK118RZP3FHB", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3175), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFSTS3J5AETX0AK92VB9F3D", null },
                    { "01HTFWGNWFAER1ZK118RZP3FHC", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3177), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFSTS3J5AETX0AK92VB9F3E", null },
                    { "01HTFWGNWFAER1ZK118RZP3FHD", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3178), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFSTS3J5AETX0AK92VB9F3F", null }
                });

            migrationBuilder.InsertData(
                schema: "segu",
                table: "UsuarioRol",
                columns: new[] { "IdUsuarioRol", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "IdRol", "IdUsuario", "Modificado_por" },
                values: new object[,]
                {
                    { "01HTFWGNWFAER1ZK118RZP3FHA", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3069), null, "01HTFTW32KEH24P284SNVH8QPD", "01HTFSTS3J5AETX0AK92VB9F4D", null },
                    { "01HTFWGNWFAER1ZK118RZP3FHB", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3071), null, "01HTFTWFZ6KMPARYMV6RKBBKTG", "01HTFSTS3J5AETX0AK92VB9F3D", null },
                    { "01HTFWGNWFAER1ZK118RZP3FHC", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3073), null, "01HTFTXWJKVS3CN09Y479MG23D", "01HTFSTS3J5AETX0AK92VB9F3E", null },
                    { "01HTFWGNWFAER1ZK118RZP3FHD", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3075), null, "01HTFTXWJKVS3CN09Y479MG23D", "01HTFSTS3J5AETX0AK92VB9F3F", null }
                });

            migrationBuilder.InsertData(
                schema: "conf",
                table: "PerfilExamen",
                columns: new[] { "IdPerfilExamen", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "IdExamen", "IdPerfil", "Modificado_por" },
                values: new object[,]
                {
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(4175), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXR", "01HTFVC8V8BDJVZ8T4Y9GTGFXV1", null },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXS", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(4178), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXS", "01HTFVC8V8BDJVZ8T4Y9GTGFXV1", null },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXT", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(4179), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXT", "01HTFVC8V8BDJVZ8T4Y9GTGFXV1", null },
                    { "01HTFVC8V8BDJVZ8T4Y9GTGFXV", "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(4182), null, "01HTFVC8V8BDJVZ8T4Y9GTGFXV", "01HTFVC8V8BDJVZ8T4Y9GTGFXV1", null }
                });

            migrationBuilder.InsertData(
                schema: "segu",
                table: "UsuarioRolPermiso",
                columns: new[] { "IdUsuarioRolPermiso", "Accion", "Creado_por", "Estado", "Fecha_creacion", "Fecha_modificacion", "IdPermiso", "IdUsuarioRol", "Modificado_por" },
                values: new object[,]
                {
                    { 1, "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3141), null, "BBHTFWGNWFAER1ZK118RZP3FHA", "01HTFWGNWFAER1ZK118RZP3FHA", null },
                    { 2, "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3143), null, "BBHTFWGNWFAER1ZK118RZP3FHB", "01HTFWGNWFAER1ZK118RZP3FHA", null },
                    { 3, "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3146), null, "BBHTFWGNWFAER1ZK118RZP3FHC", "01HTFWGNWFAER1ZK118RZP3FHA", null },
                    { 4, "CREA", "ADMIN", "ACTI", new DateTime(2024, 11, 2, 14, 53, 27, 929, DateTimeKind.Local).AddTicks(3148), null, "BBHTFWGNWFAER1ZK118RZP3FHD", "01HTFWGNWFAER1ZK118RZP3FHA", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_IdLaboratorio",
                schema: "conf",
                table: "Area",
                column: "IdLaboratorio");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoMedicoAnalizador_IdEquipoMedico",
                schema: "conf",
                table: "EquipoMedicoAnalizador",
                column: "IdEquipoMedico");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoMedicoExamen_IdEquipoMedico",
                schema: "conf",
                table: "EquipoMedicoExamen",
                column: "IdEquipoMedico");

            migrationBuilder.CreateIndex(
                name: "IX_EquipoMedicoExamen_IdExamen",
                schema: "conf",
                table: "EquipoMedicoExamen",
                column: "IdExamen");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_IdArea",
                schema: "conf",
                table: "Examen",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_Examen_IdTipoMuestra",
                schema: "conf",
                table: "Examen",
                column: "IdTipoMuestra");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenRango_IdExamen",
                schema: "conf",
                table: "ExamenRango",
                column: "IdExamen");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdPersona",
                schema: "labo",
                table: "Medico",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_NavbarPermiso_IdNavbar",
                schema: "segu",
                table: "NavbarPermiso",
                column: "IdNavbar");

            migrationBuilder.CreateIndex(
                name: "IX_NavbarRelacion_IdNavbarPrincipal",
                schema: "segu",
                table: "NavbarRelacion",
                column: "IdNavbarPrincipal");

            migrationBuilder.CreateIndex(
                name: "IX_NavbarRelacionRol_IdRol",
                schema: "segu",
                table: "NavbarRelacionRol",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_NavbarRelacionRol_navbarRelacionIdNavbarRelacion",
                schema: "segu",
                table: "NavbarRelacionRol",
                column: "navbarRelacionIdNavbarRelacion");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenExamen_IdExamen",
                schema: "labo",
                table: "OrdenExamen",
                column: "IdExamen");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenExamen_IdOrden",
                schema: "labo",
                table: "OrdenExamen",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenExamen_Idperfil",
                schema: "labo",
                table: "OrdenExamen",
                column: "Idperfil");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaciente_IdMedico",
                schema: "labo",
                table: "OrdenPaciente",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaciente_IdOrden",
                schema: "labo",
                table: "OrdenPaciente",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaciente_IdOrigen",
                schema: "labo",
                table: "OrdenPaciente",
                column: "IdOrigen");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaciente_IdPaciente",
                schema: "labo",
                table: "OrdenPaciente",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaciente_IdProcedencia",
                schema: "labo",
                table: "OrdenPaciente",
                column: "IdProcedencia");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPaciente_IdServicio",
                schema: "labo",
                table: "OrdenPaciente",
                column: "IdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdPersona",
                schema: "labo",
                table: "Paciente",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilExamen_IdExamen",
                schema: "conf",
                table: "PerfilExamen",
                column: "IdExamen");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilExamen_IdPerfil",
                schema: "conf",
                table: "PerfilExamen",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_QCRango_IdExamen",
                schema: "crca",
                table: "QCRango",
                column: "IdExamen");

            migrationBuilder.CreateIndex(
                name: "IX_QCRango_IdLote",
                schema: "crca",
                table: "QCRango",
                column: "IdLote");

            migrationBuilder.CreateIndex(
                name: "IX_QCRango_IdNivel",
                schema: "crca",
                table: "QCRango",
                column: "IdNivel");

            migrationBuilder.CreateIndex(
                name: "IX_ReactivoDet_IdExamen",
                schema: "crca",
                table: "ReactivoDet",
                column: "IdExamen");

            migrationBuilder.CreateIndex(
                name: "IX_ReactivoDet_IdReactivo",
                schema: "crca",
                table: "ReactivoDet",
                column: "IdReactivo");

            migrationBuilder.CreateIndex(
                name: "IX_ReactivoExamen_IdExamen",
                schema: "crca",
                table: "ReactivoExamen",
                column: "IdExamen");

            migrationBuilder.CreateIndex(
                name: "IX_ReactivoExamen_IdReactivoDet",
                schema: "crca",
                table: "ReactivoExamen",
                column: "IdReactivoDet");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaClienteExamen_IdExamen",
                schema: "conf",
                table: "SistemaClienteExamen",
                column: "IdExamen");

            migrationBuilder.CreateIndex(
                name: "IX_SistemaClienteExamen_IdSistemaCliente",
                schema: "conf",
                table: "SistemaClienteExamen",
                column: "IdSistemaCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPersona",
                schema: "segu",
                table: "Usuario",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioArea_IdArea",
                schema: "segu",
                table: "UsuarioArea",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioArea_IdUsuario",
                schema: "segu",
                table: "UsuarioArea",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioHospital_IdHospital",
                schema: "segu",
                table: "UsuarioHospital",
                column: "IdHospital");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioHospital_IdUsuario",
                schema: "segu",
                table: "UsuarioHospital",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_IdRol",
                schema: "segu",
                table: "UsuarioRol",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_IdUsuario",
                schema: "segu",
                table: "UsuarioRol",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRolPermiso_IdPermiso",
                schema: "segu",
                table: "UsuarioRolPermiso",
                column: "IdPermiso");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRolPermiso_IdUsuarioRol",
                schema: "segu",
                table: "UsuarioRolPermiso",
                column: "IdUsuarioRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipoMedicoAnalizador",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "EquipoMedicoExamen",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "ExamenRango",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "NavbarPermiso",
                schema: "segu");

            migrationBuilder.DropTable(
                name: "NavbarRelacionRol",
                schema: "segu");

            migrationBuilder.DropTable(
                name: "OrdenExamen",
                schema: "labo");

            migrationBuilder.DropTable(
                name: "OrdenPaciente",
                schema: "labo");

            migrationBuilder.DropTable(
                name: "PerfilExamen",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "QCRango",
                schema: "crca");

            migrationBuilder.DropTable(
                name: "QCResultado",
                schema: "crca");

            migrationBuilder.DropTable(
                name: "ReactivoExamen",
                schema: "crca");

            migrationBuilder.DropTable(
                name: "Reporte",
                schema: "rpt");

            migrationBuilder.DropTable(
                name: "SistemaClienteExamen",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "TablaMaestra",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Tracking",
                schema: "trak");

            migrationBuilder.DropTable(
                name: "UsuarioArea",
                schema: "segu");

            migrationBuilder.DropTable(
                name: "UsuarioHospital",
                schema: "segu");

            migrationBuilder.DropTable(
                name: "UsuarioRolPermiso",
                schema: "segu");

            migrationBuilder.DropTable(
                name: "EquipoMedico",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "NavbarRelacion",
                schema: "segu");

            migrationBuilder.DropTable(
                name: "Medico",
                schema: "labo");

            migrationBuilder.DropTable(
                name: "Orden",
                schema: "labo");

            migrationBuilder.DropTable(
                name: "Origen",
                schema: "labo");

            migrationBuilder.DropTable(
                name: "Paciente",
                schema: "labo");

            migrationBuilder.DropTable(
                name: "Procedencia",
                schema: "labo");

            migrationBuilder.DropTable(
                name: "Servicio",
                schema: "labo");

            migrationBuilder.DropTable(
                name: "Perfil",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Lote",
                schema: "crca");

            migrationBuilder.DropTable(
                name: "Nivel",
                schema: "crca");

            migrationBuilder.DropTable(
                name: "ReactivoDet",
                schema: "crca");

            migrationBuilder.DropTable(
                name: "SistemaCliente",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Hospital",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Permiso",
                schema: "segu");

            migrationBuilder.DropTable(
                name: "UsuarioRol",
                schema: "segu");

            migrationBuilder.DropTable(
                name: "Navbar",
                schema: "segu");

            migrationBuilder.DropTable(
                name: "Examen",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Reactivo",
                schema: "crca");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "segu");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "segu");

            migrationBuilder.DropTable(
                name: "Area",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "TipoMuestra",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Persona",
                schema: "conf");

            migrationBuilder.DropTable(
                name: "Laboratorio",
                schema: "conf");
        }
    }
}
