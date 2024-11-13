namespace Persistence.Database.CurrentUser.Service
{
    public interface ICurrentUserService
    {
        string Usuario { get; }
        string IdHospital { get; }
        string IdClient { get; }
    }
}
