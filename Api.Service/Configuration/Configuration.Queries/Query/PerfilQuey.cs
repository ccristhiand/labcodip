namespace Configuration.Service.Queries.Query
{
    public class PerfilQuey
    {
        public string? IdPerfil { get; set; }
        public string? Nombre { get; set; }
        public string? Estado { get; set; }
        public int? Codigo { get; set; }
        public List<PerfilExamenQuery>? PerfilExamenes { get; set; }
    }
}
