namespace Common.Utility
{
    public class DataBase
    {
        public const int SILAC_CONFIG = 1;
        public const int SILAC_SILAC_WEB = 2;
    }

    public class User
    {
        public const string SuperUsuario = "01HTFTW32KEH24P284SNVH8QPD";
    }
    public class UserLaboratorio
    {
        public const string Emergencia = "01HTFVDVESJX8XN6H29Z3WVN9M";
    }

    public class KeyMessage
    {
        public const string Key = "tst";
    }

    public class TypeResponse
    {
        public const string Success = "success";
        public const string Alert = "warn";
        public const string Error = "error";
    }

    public class Summary
    {
        public const string Success = "ÉXITO";
        public const string Alert = "ADVERTENCIA";
        public const string Error = "ERROR";
    }

    public class MsgUser
    {
        public const string SuccesUser = "Bienvenido al sistema de SILAC WEB.";
        public const string ErrorUser = "El nombre del usuario o contraseña es incrorrecta.";
    }

    public class Messages
    {
        public string Validar(string tabla) { return $"{tabla} se validado con exito"; }
        public string ErrorValidar(string tabla) { return $"error al validar {tabla}"; }
        public string PreValidar(string tabla) { return $"{tabla} se pre valido con exito"; }
        public string ErrorPreValidar(string tabla) { return $"error al pre validar {tabla}"; }
        public string Examen(string tabla) { return $"Se agrego el examen con exito"; }
        public string ErrorExamen(string tabla) { return $"Error al agregar el examen"; }
        public string Guardar(string tabla) { return $"{tabla} guardado con exito"; }
        public string ErrorGuardar(string tabla) { return $"error al guardar {tabla}"; }
        public string NoExiste(string tabla) { return $"{tabla} no existe"; }
        public string YaExiste(string tabla) { return $"{tabla} ya existe intente con otro"; }
        public string Eliminar(string tabla) { return $"{tabla} eliminado con exito"; }
        public string ErrorEliminar(string tabla) { return $"error al eliminar {tabla}"; }
        public string Activar(string tabla) { return $"{tabla} se activo con exito"; }
        public string Desactivar(string tabla) { return $"{tabla} se desactivo con exito"; }
        public string Actualizar(string tabla) { return $"{tabla} actualizado correctamente"; }
        public string ErrorActualizar(string tabla) { return $"error al Actualizar {tabla}"; }
        public string CambioEstado() { return $"cambio de estado exitoso"; }
        public string ErrorCambioEstado() { return $"error al cambiar el estado"; }
        public string ErrorEliminarRelacion(string tabla1, string tabla2) { return $"{tabla1} Error al eliminar ya tiene una relacion con {tabla2}"; }
        public string ErrorDesactivarRelacion(string tabla1, string tabla2) { return $"{tabla1} Error en desactivar ya tiene una relacion con {tabla2}"; }

        public string QuitarValidacion(string tabla) { return $"{tabla} quito validación con exito"; }
        public string ErrorQuitarValidacion(string tabla) { return $"error en quitar la validación"; }

    }

    public class Actions
    {
        public const string Creado = "CREA";
        public const string Modificado = "MODI";
        public const string Eliminado = "ELIM";
    }

    public class States
    {
        public const string Activo = "ACTI";
        public const string Desactivado = "DESA";
        public const string Eliminado = "ELIM";
        public const string Prevalidado = "PREV";
        public const string Pendiente = "PEND";
        public const string PorValidar = "PVAL";
        public const string Validado = "VALI";
    }


    public class ModoCalibracion
    {
        public const string PorExamen = "MO01";
        public const string PorControl = "MO02";
    }

    public class Opciones
    {
        public const string States = "States";
        public const string Actions = "Actions";
        public const string Sexo = "Sexo";
        public const string TipoDocumento = "TipoDocumento";
        public const string TipoOrden = "TipoOrden";
        public const string PorEstado = "EstadoOrden";
        public const string Interpretado = "Interpretado";
        public const string TipoConfRango = "TipoConfRango";
        public const string SignoComparativo = "SignoComparativo";
        public const string Interpretado2 = "Interpretado2";

        public const string PorOrden = "ORDE";
        public const string PorExamen = "EXAM";
        public const string TipoBaseDato = "TipoBaseDato";

        public const string AMBOS = "AMBO";
        public const string MASCULINO = "MASC";
        public const string FEMENINO = "FEME";

        public const string NOREACTIVO = "NORE";
        public const string INDETERMINADO = "INDE";
        public const string REACTIVO = "REAC";

        public const string POSITIVO = "POS";
        public const string INDETERMI = "IND";
        public const string NEGATIVO = "NEG";
        public const string RangoNumerico = "INT3";


    }

    public class Forms
    {
        public const string Area = "Area";
        public const string EquipoMedico = "EquipoMedico";
        public const string EquipoMedicoAnalizador = "EquipoMedicoAnalizador";
        public const string EquipoMedicoExamen = "EquipoMedicoExamen";
        public const string Examen = "Examen";
        public const string ExamenRango = "ExamenRango";
        public const string Hospital = "Hospital";
        public const string Laboratorio = "Laboratorio";
        public const string Persona = "Persona";
        public const string SistemaCliente = "SistemaCliente";
        public const string SistemaClienteExamen = "SistemaClienteExamen";
        public const string TablaMaestra = "TablaMaestra";
        public const string TipoMuestra = "TipoMuestra";
        public const string Calibracion = "Calibracion";
        public const string Control = "Control";
        public const string ControlExamen = "ControlExamen";
        public const string Lote = "Lote";
        public const string Nivel = "Nivel";
        public const string RangoQC = "RangoQC";
        public const string Medico = "Medico";
        public const string Orden = "Orden";
        public const string OrdenExamen = "OrdenExamen";
        public const string Paciente = "Paciente";
        public const string Navbar = "Navbar";
        public const string NavbarPermiso = "NavbarPermiso";
        public const string Permiso = "Permiso";
        public const string Rol = "Rol";
        public const string Usuario = "Usuario";
        public const string UsuarioArea = "UsuarioArea";
        public const string UsuarioHospital = "UsuarioHospital";
        public const string UsuarioLaboratorio = "UsuarioLaboratorio";
        public const string UsuarioRol = "UsuarioRol";
        public const string Procedencia = "Procedencia";
        public const string Servicio = "Servicio";
        public const string Origen = "Origen";
        public const string Reactivo = "Reactivo";
        public const string Resultado = "Resultado";
        public const string ReactivoDet = "Detalle del reactivo";
        public const string Modo = "Modo";
        public const string Perfil = "Perfil";
        public const string PerfilExamen = "PerfilExamen";

    }
    public class movimientoTracking
    {
        public const int TrcImpresionEtiqueta = 1;
        public const int TrcLecturaDeEquipoMedico = 2;
        public const int TrcEnvioDeResultado = 3;
        public const int TrcPrevalidacionMedica = 4;
        public const int TrcValidacionMedica = 5;

    }


    public class Transaccion
    {
        public const string RangoMinimo = "Rango Inicial:";
        public const string RangoMedio = "Rango Media:";
        public const string Desviacion = "Desviación:";
        public const string RangoMaximo = "Rango Final:";
    }

    public class ColorRango
    {
        public const string RangoMinimo = "#0BD18A";
        public const string RangoMedio = "#0F8BFD";
        public const string Desviacion = "#FC6161";
        public const string RangoMaximo = "#0BD18A";
    }

    public class IconRango
    {
        public const string RangoMinimo = "pi pi-plus";
        public const string RangoMedio = "pi pi-check";
        public const string Desviacion = "pi pi-refresh";
        public const string RangoMaximo = "pi pi-plus";
    }

}
