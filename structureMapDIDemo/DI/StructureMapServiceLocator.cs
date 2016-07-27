using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace structureMapDIDemo.DI
{
    public class StructureMapServiceLocator : IServiceLocator
    {
        private readonly Container _container;

        public StructureMapServiceLocator(Container container)
        {
            if (container != null)
                _container = container;
        }

        public object GetService(Type serviceType) => _container.TryGetInstance(serviceType);

        public object GetInstance(Type serviceType) => _container.GetInstance(serviceType);

        public object GetInstance(Type serviceType, string key) => _container.GetInstance(serviceType, key);

        public IEnumerable<object> GetAllInstances(Type serviceType)
            => _container.GetAllInstances(serviceType).Cast<object>();

        public TService GetInstance<TService>() => _container.GetInstance<TService>();

        public TService GetInstance<TService>(string key) => _container.GetInstance<TService>(key);

        public IEnumerable<TService> GetAllInstances<TService>() => _container.GetAllInstances<TService>();
    }
}