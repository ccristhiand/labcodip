namespace External.Service.Reniec.Dto
{
    public class ReniecDto
    {
        public ReniecDto() { }
        public List<MessageData>? Messages { get; set; }
        public personDto? Data { get; set; }
        public bool? IsSuccess { get; set; }
    }

    public class MessageData
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
        public string? Type { get; set; }
    }
    public class personDto
    {
        public string? Dni { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
    }
}
