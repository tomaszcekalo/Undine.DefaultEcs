using DefaultEcs;
using Undine.Core;

namespace Undine.DefaultEcs
{
    public class DefaultEntity : IUnifiedEntity
    {
        private Entity _entity;
        public DefaultEntity(Entity entity)
        {
            _entity = entity;
        }
        public void AddComponent<A>(in A component)
            where A : struct
        {
            _entity.Set(component);
        }

        public ref A GetComponent<A>()
            where A : struct
        {
            return ref _entity.Get<A>();
        }
    }
}