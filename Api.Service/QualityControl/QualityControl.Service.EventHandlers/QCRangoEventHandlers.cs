using Common.Config;
using Common.Utility;
using Laboratory.Service.EventHandlers;
using Persistence.Database;
using Silac.Domain;

namespace QualityControl.Service.EventHandlers
{
    public interface IQCRangoEventHandlers
    {
        Task<ResponseCreateCommand> Post(QCRangoCreateCommand command);
    }

    public class QCRangoEventHandlers : IQCRangoEventHandlers
    {
        private readonly PersistenceDatabase _dbContext;

        public QCRangoEventHandlers(PersistenceDatabase dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseCreateCommand> Post(QCRangoCreateCommand command)
        {
            ResponseCreateCommand response = new ResponseCreateCommand();
            try
            {
                var qcRango = _dbContext.QCRango.FirstOrDefault(x => x.IdReactivoDet == command.IdReactivoDet &&
                                                                x.IdLote == command.IdLote &&
                                                                x.IdNivel == command.IdNivel &&
                                                                x.IdExamen == command.IdExamen);

                if (qcRango == null)
                {
                    var model = DtoMapperExtension.MapTo<QCRango>(command);

                    model.IdQCRango = Ulid.NewUlid().ToString();
                    model.Creado_por = command.user;
                    model.Fecha_creacion = DateTime.Now;
                    model.Estado = States.Activo;
                    model.Accion = Actions.Creado;

                    await _dbContext.QCRango.AddAsync(model);
                }
                else
                {
                    qcRango.IdExamen = command.IdExamen;
                    qcRango.IdLote = command.IdLote;
                    qcRango.IdNivel = command.IdNivel;
                    qcRango.RangoMinimo = command.RangoMinimo;
                    qcRango.RangoMedio = command.RangoMedio;
                    qcRango.RangoMaximo = command.RangoMaximo;
                    qcRango.Desviacion = command.Desviacion;
                    qcRango.Modificado_por = command.user;
                    qcRango.Fecha_modificacion = DateTime.Now;
                    qcRango.Accion = Actions.Modificado;
                }

                await _dbContext.SaveChangesAsync();

                response = Configurations.Response(new Messages().Guardar(Forms.RangoQC), TypeResponse.Success);

                return response;
            }
            catch (Exception)
            {
                return response = Configurations.Response(new Messages().ErrorGuardar(Forms.RangoQC), TypeResponse.Error);
            }
        }

    }
}