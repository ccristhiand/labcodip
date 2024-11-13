using Configuration.Service.Queries.Query;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;


namespace Configuration.Service.Queries
{
    public interface IHospitalQueryService
    {
        Task<HospitalQuery> Find();
    }
    public class HospitalQueryService : IHospitalQueryService
    {
        private readonly PersistenceDatabase _dbContext;

        public HospitalQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HospitalQuery> Find()
        {
            var response = await _dbContext
                            .Hospital.AsNoTracking()
                            .Select(h => new HospitalQuery
                            {
                                CodigoHospital = h.CodigoHospital,
                                IdHospital = h.IdHospital,
                                Nombre = h.Nombre,
                                Titulo = h.Titulo,
                                SubTitulo = h.SubTitulo,
                                Direccion = h.Direccion,
                                PiePagina = h.PiePagina,
                                Foto = h.Foto,
                                Estado = h.Estado
                            }).FirstOrDefaultAsync();

            return response!;
        }
    }
}
