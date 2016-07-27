using structureMapDIDemo.Interface;
using structureMapDIDemo.Provider;
using StructureMap;

namespace structureMapDIDemo.DI
{
    public static class StructureMapContainerProvider
    {
        public static Container GetContainer()
        {
            var registry = new Registry();
            SetUpDependencies(registry);
            return new Container(registry);
        }

        private static void SetUpDependencies(Registry registry)
        {
            registry.For<IRequestValidator>().Use<RequestValidator>();
        }
    }
}