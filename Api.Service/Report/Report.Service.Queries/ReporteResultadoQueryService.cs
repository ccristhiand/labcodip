using Dapper;
using Microsoft.Data.SqlClient;
using Persistence.Database.CurrentUser;
using Persistence.Database.CurrentUser.Service;
using Report.Service.Queries.Query;
using System.Data;

namespace Report.Service.Queries
{
    public interface IReporteResultadoQueryService
    {
        Task<List<ImprimirResultadoPacienteQuery>> GetResultadoPaciente(string? id);
    }
    public class ReporteResultadoQueryService : IReporteResultadoQueryService
    {
        private readonly ICurrentUserService _currentUserService;

        public ReporteResultadoQueryService(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<List<ImprimirResultadoPacienteQuery>> GetResultadoPaciente(string? id)
        {
            var connection = Metodo.GetByConnection().Connection.Where(y => y.IdClient == _currentUserService.IdClient)!.FirstOrDefault();

            using (var sqlConnection = new SqlConnection(connection!.Cns!))
            {
                try
                {
                    sqlConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { @id = id });

                    var response = await sqlConnection.QueryAsync<ImprimirResultadoPacienteQuery>(ReporteProcedure.spImprimirResultadoPaciente, param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: DbConnectionTime.TimeOut);

                    return response.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    sqlConnection.Dispose();
                    sqlConnection.Close();
                }
            }
        }
    }
}
