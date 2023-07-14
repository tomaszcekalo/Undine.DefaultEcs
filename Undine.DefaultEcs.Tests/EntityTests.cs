using Moq;
using Undine.Core;
using Undine.DefaultEcs.Tests.Components;

namespace Undine.DefaultEcs.Tests
{
    [TestClass]
    public class EntityTests
    {
        [TestInitialize]
        public void Init()
        {
        }

        [TestMethod]
        public void ComponentCanBeAdded()
        {
            var container = new DefaultEcsContainer();
            container.Init();
            var entity = container.CreateNewEntity();
            entity.AddComponent(new AComponent());
        }

        [TestMethod]
        public void ComponentCanBeRetrieved()
        {
            var container = new DefaultEcsContainer();
            var mock = new Mock<UnifiedSystem<AComponent>>();
            container.AddSystem(mock.Object);
            container.Init();
            var entity = (DefaultEntity)container.CreateNewEntity();
            entity.AddComponent(new AComponent());
            container.Run();//LazyECS updates components on the next frame
            ref var component = ref entity.GetComponent<AComponent>();
            Assert.IsNotNull(component);
        }//
    }
}