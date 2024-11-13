using System;
using System.Collections.Generic;

namespace Report
{
    public class EtiquetaQuery
    {
        public EtiquetaQuery()
        {
            ListaExamenOrden = new List<string>();
        }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public string NroDocumento { get; set; }
        public string Procedencia { get; set; }
        public DateTime? FechaOrden { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string NroOrden { get; set; }
        public string ExamenOrden { get; set; }
        public byte[] CodigoBarra { get; set; }

        public List<string> ListaExamenOrden { get; set; }
    }
}
