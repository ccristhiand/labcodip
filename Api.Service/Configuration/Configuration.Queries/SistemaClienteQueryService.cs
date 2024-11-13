using Common.Config;
using Common.Utility;
using Configuration.Service.Queries.Query;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

namespace Configuration.Service.Queries
{
    public interface ISistemaClienteQueryService
    {
        Task<DataCollection<SistemaClienteQuery>> Get(string? valor, int page, int pages, string column);
        Task<SistemaClienteQuery> Find(string? id);
    }
    public class SistemaClienteQueryService : ISistemaClienteQueryService
    {
        public readonly PersistenceDatabase _dbContext;
        public SistemaClienteQueryService(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataCollection<SistemaClienteQuery>> Get(string? valor, int page, int pages, string column)
        {

            try
            {
                var response = await (from sc in _dbContext.SistemaCliente
                                      join ta in _dbContext.TablaMaestra on sc.Estado equals ta.Codigo
                                      where
                                      (valor == null || sc.Nombre!.Contains(valor!)) &&
                                      ta.Tabla == Opciones.States &&
                                      sc.Estado != States.Eliminado
                                      select new SistemaClienteQuery
                                      {
                                          Codigo = sc.Codigo,
                                          IdSistemaCliente = sc.IdSistemaCliente,
                                          Nombre = sc.Nombre,
                                          Server = sc.Server,
                                          BaseDeDatos = sc.BaseDeDatos,
                                          Estado = ta.Nombre,
                                          Color = ta.Color
                                      }).GetPagedAsync();

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<SistemaClienteQuery> Find(string? id)
        {
            try
            {
                SistemaClienteQuery sistemaClienteQuery = new SistemaClienteQuery();

                if (!string.IsNullOrEmpty(id))
                {
                    var sistemCliente = await (from sc in _dbContext.SistemaCliente
                                               where
                                               sc.IdSistemaCliente == id
                                               select new SistemaClienteQuery
                                               {
                                                   IdSistemaCliente = sc.IdSistemaCliente,
                                                   Server = sc.Server,
                                                   BaseDeDatos = sc.BaseDeDatos,
                                                   Usuario = sc.Usuario,
                                                   Contrasena = sc.Contrasena,
                                                   IdTipoBaseDato = sc.IdTipoBaseDato,
                                                   Nombre = sc.Nombre,
                                                   Estado = sc.Estado,
                                                   Codigo = sc.Codigo
                                               }).FirstOrDefaultAsync();

                    sistemaClienteQuery = sistemCliente!;
                }

                var listadoTipoBaseDato = await (from ta in _dbContext.TablaMaestra
                                                 where
                                                 ta.Tabla == Opciones.TipoBaseDato
                                                 select new OptionQuery
                                                 {
                                                     Id = ta.Codigo,
                                                     Nombre = ta.Nombre,
                                                     Tipo = ta.Tabla
                                                 }).ToListAsync();

                sistemaClienteQuery.ListaOpciones = listadoTipoBaseDato;

                return sistemaClienteQuery!;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
