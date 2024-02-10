using DefaultEcs;
using Undine.Core;

namespace Undine.DefaultEcs
{
    public class DefaultEntity : IUnifiedEntity
    {
        public Entity Entity { get; set; }
        public DefaultEntity(Entity entity)
        {
            Entity = entity;
        }
        public void AddComponent<A>(in A component)
            where A : struct
        {
            Entity.Set(component);
        }

        public ref A GetComponent<A>()
            where A : struct
        {
            return ref Entity.Get<A>();
        }

        public void RemoveComponent<A>() where A : struct
        {
            Entity.Remove<A>();
        }
        public bool HasComponent<A>() where A : struct
        {
            return Entity.Has<A>();
        }
    }
}