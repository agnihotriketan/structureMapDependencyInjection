using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.ServiceLocation;

namespace structureMapDIDemo.DI
{
    public class DependencyResolver : IDependencyResolver
    {
        public IDependencyScope BeginScope() => this;

        public object GetService(Type serviceType) => ServiceLocator.Current.GetService(serviceType);

        public IEnumerable<object> GetServices(Type serviceType) => ServiceLocator.Current.GetAllInstances(serviceType);

        public void Dispose()
        {
        }
    }
}