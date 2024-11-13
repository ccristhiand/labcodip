using Common.Config;
using Common.Utility;
using Configuration.Service.EventHandlers.Commands;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Silac.Domain;

namespace Configuration.Service.EventHandlers
{
    public interface IExamenEventHandlers
    {
        Task<ResponseCreateCommand> Post(ExamenCommand command);
        Task<ResponseCreateCommand> Put(string id, ExamenCommand command);
        Task<ResponseCreateCommand> Delete(string id, string? usuario);
        Task<ResponseCreateCommand> DeleteRango(string id, string? usuario);
        Task<ResponseCreateCommand> State(string id, string? usuario);
    }
    public class ExamenEventHandlers : IExamenEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public ExamenEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseCreateCommand> Delete(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var examen = _dbContext.Examen.FirstOrDefault(x => x.IdExamen == id);

                if (examen != null)
                {
                    var existOrden = _dbContext.OrdenExamen.Any(y => y.IdExamen == id && y.Estado == States.Activo);

                    if (existOrden) return Configurations.Response(new Messages().ErrorEliminarRelacion("", Forms.Orden), TypeResponse.Alert);

                    examen.Fecha_modificacion = DateTime.Now;
                    examen.Modificado_por = usuario;
                    examen.Estado = States.Eliminado;
                    examen.Accion = Actions.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.Examen), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Examen), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.Examen), TypeResponse.Error, ex.Message);
            }
        }
        public async Task<ResponseCreateCommand> DeleteRango(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var examenRango = _dbContext.ExamenRango.FirstOrDefault(x => x.IdExamenRango == id);

                if (examenRango != null)
                {
                    examenRango.Fecha_modificacion = DateTime.Now;
                    examenRango.Modificado_por = usuario;
                    examenRango.Estado = States.Eliminado;
                    examenRango.Accion = Actions.Eliminado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Eliminar(Forms.ExamenRango), TypeResponse.Success);

                    return response;
                }
                else
                {
                    response = Configurations.Response(new Messages().NoExiste(Forms.ExamenRango), TypeResponse.Alert);
                    response.Id = (examenRango == null) ? null : id;
                    return response;
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorEliminar(Forms.ExamenRango), TypeResponse.Error, ex.Message);
            }
        }
        public async Task<ResponseCreateCommand> Post(ExamenCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var existNombre = _dbContext.Examen.Any(y => y.Nombre!.ToLower().Trim() == command.Nombre!.ToLower().Trim() && y.Estado != States.Eliminado);

                if (existNombre) return Configurations.Response(new Messages().YaExiste(Forms.Examen), TypeResponse.Alert);

                var examen = DtoMapperExtension.MapTo<Examen>(command);

                examen.IdExamen = Ulid.NewUlid().ToString();
                examen.Estado = States.Activo;
                examen.Accion = Actions.Creado;
                examen.Creado_por = command.user;
                examen.Fecha_creacion = DateTime.Now;
                examen.Color = command.Color;
                examen.TiempoTrackingMin = command.TiempoTrackingMin;

                await _dbContext.Examen.AddAsync(examen);

                command.ListaExamenRango.ForEach(y =>
                {
                    var examenRango = new ExamenRango();

                    examenRango.IdExamenRango = Ulid.NewUlid().ToString();
                    examenRango.IdExamen = examen.IdExamen;
                    examenRango.IdInterpretado = y.IdInterpretado;
                    examenRango.EdadInicio = y.EdadInicio;
                    examenRango.EdadFinal = y.EdadFinal;
                    examenRango.ValorMinimo = y.ValorMinimo;
                    examenRango.ValorMaximo = y.ValorMaximo;
                    examenRango.SigComparativo = y.SigComparativo;
                    examenRango.Estado = States.Activo;
                    examenRango.Accion = Actions.Creado;
                    examenRango.Creado_por = command.user;
                    examenRango.Fecha_creacion = DateTime.Now;

                    _dbContext.ExamenRango.AddAsync(examenRango);
                });

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.Examen), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.Examen), TypeResponse.Error);
            }
        }
        public async Task<ResponseCreateCommand> Put(string id, ExamenCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var examen = _dbContext.Examen.FirstOrDefault(x => x.IdExamen == id);

                if (examen != null)
                {
                    examen.IdTipoMuestra = command.IdTipoMuestra;
                    examen.Calculado = command.Calculado;
                    examen.Abreviatura = command.Abreviatura;
                    examen.Nombre = command.Nombre;
                    examen.UnidadMedida = command.UnidadMedida;
                    examen.CantidadDecimal = command.CantidadDecimal;
                    examen.TipoCongRango = command.TipoCongRango;
                    examen.RangoMostrar = command.RangoMostrar;
                    examen.Orden = command.Orden;
                    examen.Color = command.Color;
                    examen.TiempoTrackingMin = command.TiempoTrackingMin;
                    examen.Fecha_modificacion = DateTime.Now;
                    examen.Modificado_por = command.user;
                    examen.Accion = Actions.Modificado;

                    var examenRango = _dbContext.ExamenRango.AsNoTracking().Where(y => y.IdExamen == examen.IdExamen && y.Estado != States.Eliminado);

                    foreach (var item in examenRango)
                    {
                        _dbContext.ExamenRango.Remove(item);
                    }

                    command.ListaExamenRango.ForEach(y =>
                     {
                         var examenRango = new ExamenRango();

                         examenRango.IdExamenRango = Ulid.NewUlid().ToString();
                         examenRango.IdExamen = examen.IdExamen;
                         examenRango.IdInterpretado = y.IdInterpretado;
                         examenRango.EdadInicio = y.EdadInicio;
                         examenRango.EdadFinal = y.EdadFinal;
                         examenRango.ValorMinimo = y.ValorMinimo;
                         examenRango.ValorMaximo = y.ValorMaximo;
                         examenRango.SigComparativo = y.SigComparativo;
                         examenRango.Estado = States.Activo;
                         examenRango.Accion = Actions.Creado;
                         examenRango.Creado_por = command.user;
                         examenRango.Fecha_creacion = DateTime.Now;

                         _dbContext.ExamenRango.AddAsync(examenRango);
                     });

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().Actualizar(Forms.Examen), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Examen), TypeResponse.Error);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorActualizar(Forms.Examen), TypeResponse.Error, ex.Message);
            }
        }
        public async Task<ResponseCreateCommand> State(string id, string? usuario)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var examen = _dbContext.Examen.FirstOrDefault(x => x.IdExamen == id);

                if (examen != null)
                {
                    var existExamen = _dbContext.OrdenExamen.Any(y => y.IdExamen == id && y.Estado == States.Activo);

                    if (existExamen) return Configurations.Response(new Messages().ErrorDesactivarRelacion("", Forms.Orden), TypeResponse.Alert);

                    examen.Fecha_modificacion = DateTime.Now;
                    examen.Modificado_por = usuario;
                    examen.Estado = (examen.Estado == States.Activo ? States.Desactivado : States.Activo);
                    examen.Accion = Actions.Modificado;

                    await _dbContext.SaveChangesAsync();

                    response = Configurations.Response(new Messages().CambioEstado(), TypeResponse.Success);

                    return response;
                }
                else
                {
                    return response = Configurations.Response(new Messages().NoExiste(Forms.Examen), TypeResponse.Alert);
                }
            }
            catch (Exception ex)
            {
                return response = Configurations.Response(new Messages().ErrorCambioEstado(), TypeResponse.Error, ex.Message);
            }
        }
    }
}
