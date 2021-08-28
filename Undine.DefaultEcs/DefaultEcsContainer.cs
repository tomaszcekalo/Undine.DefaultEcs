using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using System;
using System.Collections.Generic;
using Undine.Core;

namespace Undine.DefaultEcs
{
    public class DefaultEcsContainer :
        EcsContainer
    {
        private readonly World _world;
        private readonly IParallelRunner _runner;
        private readonly List<AEntitySetSystem<float>> _systems;

        public DefaultEcsContainer()
        {
            _world = new World();
            _runner = new DefaultParallelRunner(Environment.ProcessorCount);
            _systems = new List<AEntitySetSystem<float>>();
        }
        public override void AddSystem<T>(UnifiedSystem<T> system)
        {
            _systems.Add(new DefaultSystem<T>(_world, _runner)
            {
                System = system
            });
        }

        public override void AddSystem<A, B>(UnifiedSystem<A, B> system)
        {
            _systems.Add(new DefaultSystem<A, B>(_world, _runner)
            {
                System = system
            });
        }

        public override void AddSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            _systems.Add(new DefaultSystem<A, B, C>(_world, _runner)
            {
                System = system
            });
        }

        public override void AddSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            _systems.Add(new DefaultSystem<A, B, C, D>(_world, _runner)
            {
                System = system
            });
        }

        public override IUnifiedEntity CreateNewEntity()
        {
            return new DefaultEntity(_world.CreateEntity());
        }

        public override ISystem GetSystem<A>(UnifiedSystem<A> system)
        {
            return new DefaultSystem<A>(_world, _runner, 2)
            {
                System = system
            };
        }

        public override ISystem GetSystem<A, B>(UnifiedSystem<A, B> system)
        {
            return new DefaultSystem<A, B>(_world, _runner, 2)
            {
                System = system
            };
        }

        public override ISystem GetSystem<A, B, C>(UnifiedSystem<A, B, C> system)
        {
            return new DefaultSystem<A, B, C>(_world, _runner, 2)
            {
                System = system
            };
        }

        public override ISystem GetSystem<A, B, C, D>(UnifiedSystem<A, B, C, D> system)
        {
            return new DefaultSystem<A, B, C, D>(_world, _runner, 2)
            {
                System = system
            };
        }

        public override void Run()
        {
            foreach (var system in _systems)
                system.Update(0);
        }
    }
}