using Common.Utility;
using Dapper;
using Microsoft.Data.SqlClient;
using NetBarcode;
using Persistence.Database.CurrentUser;
using Persistence.Database.CurrentUser.Service;
using Report.Service.Queries.Query;
using System.Data;
using System.Drawing.Imaging;

namespace Report.Service.Queries
{
    public interface IEtiquetaQueryService
    {
        Task<List<EtiquetaQuery>> Imprimir(RequestReport request, string usuario, string idclient);
    }
    public class EtiquetaQueryService : IEtiquetaQueryService
    {
        private readonly ICurrentUserService _currentUserService;

        public EtiquetaQueryService(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<List<EtiquetaQuery>> Imprimir(RequestReport request, string usuario, string idclient)
        {
            var data = new List<EtiquetaQuery>();

            var orden = String.Join(",", request.Data!);
            var tipoMuestra = String.Join(",", request.TipoMuestra!);

            var connection = Metodo.GetByConnection().Connection.Where(y => y.IdClient == _currentUserService.IdClient)!.FirstOrDefault();

            using (var sqlConnection = new SqlConnection(connection!.Cns!))
            {
                try
                {

                    sqlConnection.Open();
                    var parameters = new DynamicParameters();
                    parameters.AddDynamicParams(new { @IdOrden = orden, @IdTipoMuestra = tipoMuestra, @Usuario = usuario });

                    var result = sqlConnection.QueryMultiple(EtiquetaProcedure.spImprimirEtiqueta, param: parameters, commandType: CommandType.StoredProcedure, commandTimeout: DbConnectionTime.TimeOut);

                    if (result != null)
                    {
                        data = result.Read<EtiquetaQuery>().ToList();

                        foreach (var item in data)
                        {
                            item!.Edad = Configurations.calcularEdad(item.FecNac);

                            var barcode = new Barcode();

                            barcode.Configure(settings =>
                            {
                                settings.BarcodeType = BarcodeType.Code39;
                            });

                            var code = barcode.GetByteArray(item.NroOrden, ImageFormat.Png);
                            item.CodBarra = code;
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

            return data;
        }
    }
}
