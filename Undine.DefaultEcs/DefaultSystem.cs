using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Undine.Core;

namespace Undine.DefaultEcs
{
    public class DefaultSystem<T> : AEntitySetSystem<float>, ISystem
        where T : struct
    {
        public UnifiedSystem<T> System { get; set; }
        public DefaultSystem(World world, IParallelRunner runner)
            : base(world.GetEntities().With<T>().AsSet(), runner)
        {
        }
        public DefaultSystem(World world, IParallelRunner runner, int minEntityCountByRunnerIndex)
            : base(world.GetEntities().With<T>().AsSet(), runner, minEntityCountByRunnerIndex)
        {
        }
        protected override void Update(float state, in Entity entity)
        {
            ref T t = ref entity.Get<T>();
            System.ProcessSingleEntity(entity.GetHashCode(), ref t);
        }
        protected override void PreUpdate(float state)
        {
            System.PreProcess();
        }
        protected override void PostUpdate(float state)
        {
            System.PostProcess();
        }

        public void ProcessAll()
        {
            System.PreProcess();
            this.Update(0);
            System.PostProcess();
        }
    }

    public class DefaultSystem<A, B> : AEntitySetSystem<float>, ISystem
        where A : struct
        where B : struct
    {
        public UnifiedSystem<A, B> System { get; set; }
        public DefaultSystem(World world, IParallelRunner runner)
            : base(world.GetEntities().With<A>().With<B>().AsSet(), runner)
        {
        }
        public DefaultSystem(World world, IParallelRunner runner, int minEntityCountByRunnerIndex)
            : base(world.GetEntities().With<A>().With<B>().AsSet(), runner, minEntityCountByRunnerIndex)
        {
        }
        protected override void Update(float state, in Entity entity)
        {
            ref A a = ref entity.Get<A>();
            ref B b = ref entity.Get<B>();
            System.ProcessSingleEntity(entity.GetHashCode(), ref a, ref b);
        }
        protected override void PreUpdate(float state)
        {
            System.PreProcess();
        }
        protected override void PostUpdate(float state)
        {
            System.PostProcess();
        }
        public void ProcessAll()
        {
            this.Update(0);
        }
    }

    public class DefaultSystem<A, B, C> : AEntitySetSystem<float>, ISystem
        where A : struct
        where B : struct
        where C : struct
    {
        public UnifiedSystem<A, B, C> System { get; set; }
        public DefaultSystem(World world, IParallelRunner runner)
            : base(world.GetEntities().With<A>().With<B>().With<C>().AsSet(), runner)
        {
        }
        public DefaultSystem(World world, IParallelRunner runner, int minEntityCountByRunnerIndex)
            : base(world.GetEntities().With<A>().With<B>().With<C>().AsSet(), runner, minEntityCountByRunnerIndex)
        {
        }
        protected override void Update(float state, in Entity entity)
        {
            ref A a = ref entity.Get<A>();
            ref B b = ref entity.Get<B>();
            ref C c = ref entity.Get<C>();
            System.ProcessSingleEntity(0, ref a, ref b, ref c);
        }
        protected override void PreUpdate(float state)
        {
            System.PreProcess();
        }
        protected override void PostUpdate(float state)
        {
            System.PostProcess();
        }
        public void ProcessAll()
        {
            System.PreProcess();
            this.Update(0);
            System.PostProcess();
        }
    }

    public class DefaultSystem<A, B, C, D> : AEntitySetSystem<float>, ISystem
        where A : struct
        where B : struct
        where C : struct
        where D : struct
    {
        public UnifiedSystem<A, B, C, D> System { get; set; }
        public DefaultSystem(World world, IParallelRunner runner)
            : base(world.GetEntities().With<A>().With<B>().With<C>().With<D>().AsSet(), runner)
        {
        }
        public DefaultSystem(World world, IParallelRunner runner, int minEntityCountByRunnerIndex)
           : base(world.GetEntities().With<A>().With<B>().With<C>().With<D>().AsSet(), runner, minEntityCountByRunnerIndex)
        {
        }
        protected override void Update(float state, in Entity entity)
        {
            ref A a = ref entity.Get<A>();
            ref B b = ref entity.Get<B>();
            ref C c = ref entity.Get<C>();
            ref D d = ref entity.Get<D>();
            System.ProcessSingleEntity(0, ref a, ref b, ref c, ref d);
        }
        protected override void PreUpdate(float state)
        {
            System.PreProcess();
        }
        protected override void PostUpdate(float state)
        {
            System.PostProcess();
        }
        public void ProcessAll()
        {
            System.PreProcess();
            this.Update(0);
            System.PostProcess();
        }
    }
}