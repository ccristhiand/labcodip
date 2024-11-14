namespace External.Service.Reniec.Dto
{
    public class ReniecDto
    {
        public string? Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
    }

    public class MessageData
    {
        public string? Dni { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public List<int>? FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
    }
}
