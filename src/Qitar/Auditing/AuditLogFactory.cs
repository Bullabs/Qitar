using Qitar.Entities;
using Qitar.Repositories;
using Qitar.Serialization;
using Qitar.Utils;
using System.Threading.Tasks;

namespace Qitar.Auditing
{
    public class AuditLogFactory<TEntity> : IAuditLogFactory<TEntity> where TEntity : class, IEntity
    {
        private readonly IReadonlyRepository<TEntity> _repository;
        private readonly ISerializer _serializer;
        private readonly IGuidFactory _guidFactory;

        public AuditLogFactory(IReadonlyRepository<TEntity> repository, ISerializer serializer, IGuidFactory guidFactory)
        {
            _repository = repository.NotNull();
            _serializer = serializer.NotNull();
            _guidFactory = guidFactory.NotNull();
        }
        public async ValueTask<IAuditLog> Create(TEntity entity)
        {
            var oldEntity =  await _repository.GetById(entity.Id);

            return new AuditLog
            {
                Id = await _guidFactory.Create(entity.Id),
                PrimaryKey = entity.Id,
                TableName = entity.GetType().Name,
                NewValues = await _serializer.Serialize(entity, default),
                OldValues = await _serializer.Serialize(oldEntity, default)
            };
        }
    }
}
