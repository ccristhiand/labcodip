using Common.Config;
using Common.Utility;
using Dapper;
using Microsoft.Data.SqlClient;
using Persistence.Database.CurrentUser;
using Persistence.Database.CurrentUser.Service;
using Report.Service.Queries.Query;
using System.Data;

namespace Report.Service.Queries
{
    public interface IReporteGraficoQueryService
    {
        Task<DataCollection<OrdenPorPacienteQuery>> GetOrdenPaciente(RequestReport request);
        Task<List<OrdenPorPacienteQuery>> Exportar(RequestReport request);
        Task<DataCollection<ResultadoPaciente>> GetPaciente(string? valor);
        Task<ResultadoPacienteQuery> GetResultadoPaciente(string? id);
    }
    public class ReporteGraficoQueryService : IReporteGraficoQueryService
    {
        private readonly ICurrentUserService _currentUserService;

        public ReporteGraficoQueryService(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        public async Task<DataCollection<OrdenPorPacienteQuery>> GetOrdenPaciente(RequestReport request)
        {
            var data = new DataCollection<OrdenPorPacienteQuery>();

            var connection = Metodo.GetByConnection().Connection.Where(y => y.IdClient == _currentUserService.IdClient)!.FirstOrDefault();

            using (var sqlConnection = new SqlConnection(connection!.Cns!))
            {
                try
                {

                    sqlConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { @valor = request.Valor, @fechaInicio = request.FechaInicio, @fechaFin = request.FechaFin });

                    var result = sqlConnection.QueryMultiple(ReporteProcedure.spBuscarOrdenPorPaciente, param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: DbConnectionTime.TimeOut);

                    if (result != null)
                    {
                        var lista = result.Read<OrdenPorPacienteQuery>();
                        data.Items = lista;
                        //data.Pagination = result.ReadFirst<Pagination>();
                    }
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

            return data;
        }

        public async Task<List<OrdenPorPacienteQuery>> Exportar(RequestReport request)
        {
            var data = new List<OrdenPorPacienteQuery>();
            var connection = Metodo.GetByConnection().Connection.Where(y => y.IdClient == _currentUserService.IdClient)!.FirstOrDefault();

            using (var sqlConnection = new SqlConnection(connection!.Cns!))
            {
                try
                {

                    sqlConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { @Valor = request.Valor, @fechaInicio = request.FechaInicio, @fechaFin = request.FechaFin });

                    var result = sqlConnection.QueryMultiple(ReporteProcedure.spBuscarOrdenPorPaciente, param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: DbConnectionTime.TimeOut);

                    if (result != null)
                    {
                        data = result.Read<OrdenPorPacienteQuery>().ToList();
                    }
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

            return data;
        }

        public async Task<DataCollection<ResultadoPaciente>> GetPaciente(string? valor)
        {
            var data = new DataCollection<ResultadoPaciente>();
            var connection = Metodo.GetByConnection().Connection.Where(y => y.IdClient == _currentUserService.IdClient)!.FirstOrDefault();

            using (var sqlConnection = new SqlConnection(connection!.Cns!))
            {
                try
                {

                    sqlConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { @valor = valor });

                    var result = sqlConnection.QueryMultiple(ReporteProcedure.spBuscarPaciente, param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: DbConnectionTime.TimeOut);

                    if (result != null)
                    {
                        var lista = result.Read<ResultadoPaciente>();
                        data.Items = lista;
                        //data.Pagination = result.ReadFirst<Pagination>();
                    }
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

            return data;
        }

        public async Task<ResultadoPacienteQuery> GetResultadoPaciente(string? id)
        {
            var model = new ResultadoPacienteQuery();
            var connection = Metodo.GetByConnection().Connection.Where(y => y.IdClient == _currentUserService.IdClient)!.FirstOrDefault();

            using (var sqlConnection = new SqlConnection(connection!.Cns!))
            {
                try
                {

                    sqlConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { @id = id });

                    var result = sqlConnection.QueryMultiple(ReporteProcedure.spBuscarResultadoPaciente, param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: DbConnectionTime.TimeOut);

                    if (result != null)
                    {
                        var data = result.Read<ResultadoPaciente>().ToList();
                        var existeDato = data.Where(y => y.FechaResultado != null).Any();

                        if (existeDato)
                        {
                            var fecha = data.Where(y => y.Resultado != null).GroupBy(y => y.FechaResultado!.Value.ToString("dd/MM/yyyy"));
                            var examen = data.Where(y => y.Resultado != null).GroupBy(y => y.Abreviatura);

                            foreach (var item in fecha)
                            {
                                model.ListaFecha.Add(item.FirstOrDefault()!.FechaResultado!.Value.ToString("dd/MM/yyyy"));
                            }

                            foreach (var item in examen)
                            {
                                GraficoPaciente graficoPaciente = new GraficoPaciente();

                                var color = item.FirstOrDefault()!.Color;

                                graficoPaciente.Label = item.FirstOrDefault()!.Abreviatura;
                                graficoPaciente.BackgroundColor = (color == null) ? "green" : color;
                                graficoPaciente.BorderColor = (color == null) ? "green" : color;
                                graficoPaciente.Tension = "0.4";
                                graficoPaciente.PointRadius = "7";
                                graficoPaciente.Data = item.Select(y => y.Resultado!).ToList();

                                model.ListaGraficoPaciente.Add(graficoPaciente);
                            }
                            model.ListaResultadoPaciente = data.Where(y => y.Resultado != null).ToList();
                        }
                    }
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

            return model;
        }

    }
}
