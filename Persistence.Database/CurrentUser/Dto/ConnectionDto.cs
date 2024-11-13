namespace Persistence.Database.CurrentUser.Dto
{
    public class ConnectionData
    {
        public List<Connection> Connection { get; set; } = [];
    }
    public class Connection
    {
        public string? IdClient { get; set; }
        public string? Domain { get; set; }
        public string? SoftwareType { get; set; }
        public string? Cns { get; set; }

    }
}
