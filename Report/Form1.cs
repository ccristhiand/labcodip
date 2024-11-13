using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Report
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region [Query]
            //List<EtiquetaQuery> model = new List<EtiquetaQuery>();

            //model.Add(new EtiquetaQuery
            //{
            //    NroOrden = "00001",
            //    FechaOrden = DateTime.Now,
            //    FechaNacimiento = DateTime.Now,
            //    Nombre = "JAME JAMES FLORES",
            //    NroDocumento = "45036121",
            //    Edad = 33,
            //    ExamenOrden = "FC,DC,ER"
            //});

            //model.Add(new EtiquetaQuery
            //{
            //    NroOrden = "00002",
            //    FechaOrden = DateTime.Now,
            //    FechaNacimiento = DateTime.Now,
            //    Nombre = "TOME TOME TOMES",
            //    NroDocumento = "45036241",
            //    Edad = 40,
            //    ExamenOrden = "FC,DC,ER"
            //});

            List<ImprimirResultadoPacienteQuery> model = new List<ImprimirResultadoPacienteQuery>
            {
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "Juan Pérez",
                    NroDocumento = "12345678",
                    FechaNacimiento = new DateTime(1985, 5, 15),
                    Sexo = "Masculino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Sangre",
                    Resultado = "Normal",
                    UnidadMedida = "mg/dL",
                    Medico = "Dr. López",
                    RangoMostrar = "70-100",
                    NombreArea = "Hematología",
                    NombrePerfil = "Perfil Básico",
                    Titulo = "CLINICA 1"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina 0",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario 1",
                    Titulo = "CLINICA "
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina 1",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario 1",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina 2",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario 1",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina 3",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario 2",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina 4",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario 2",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario 3",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario 3",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },

                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                },
                new ImprimirResultadoPacienteQuery
                {
                    NombreCompleto = "María Gómez",
                    NroDocumento = "87654321",
                    FechaNacimiento = new DateTime(1990, 8, 22),
                    Sexo = "Femenino",
                    FechaOrden = DateTime.Now,
                    Examen = "Examen de Orina",
                    Resultado = "Anormal",
                    UnidadMedida = "g/L",
                    Medico = "Dr. Fernández",
                    RangoMostrar = "0-0.5",
                    NombreArea = "Urología",
                    NombrePerfil = "Perfil Urinario",
                    Titulo = "CLINICA"
                }

            };


            #endregion

            #region [Reporte]
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.ReportPath = (@"D:\pruebas_desarrollo\Francisco\LabCodip-BackEnd\Report\Desing\ResultadoPaciente.rdlc");

            ReportDataSource rds = new ReportDataSource("ResultadoPaciente", model);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            #endregion

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
