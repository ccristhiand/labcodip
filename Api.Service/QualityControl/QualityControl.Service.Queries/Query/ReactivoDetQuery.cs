namespace QualityControl.Service
{
    public class ReactivoDetQuery
    {
        public ReactivoDetQuery()
        {
            ListaReactivoExamen = new List<ReactivoExamenQuery>();
        }
        public string? IdReactivoDet { get; set; }

        public string? IdReactivo { get; set; }

        public string? IdExamen { get; set; }

        public string? Nombre { get; set; }

        public string? Estado { get; set; }

        public List<ReactivoExamenQuery> ListaReactivoExamen { get; set; }

    }
}
