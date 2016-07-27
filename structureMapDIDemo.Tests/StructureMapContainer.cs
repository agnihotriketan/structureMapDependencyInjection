using System;
using System.Collections.Generic;
using System.Linq;
using Kenobi.Common.TenantConfiguration.DataProvider;
using Microsoft.Practices.ServiceLocation;
using StructureMap;
using Tavisca.Frameworks.Logging;

namespace structureMapDIDemo.Tests
{
    public static class StructureMapContainer
    {
        public static void SetLocatorWithContainer()
        {
            var smContainer = GetStructureMapContainer();
            ServiceLocator.SetLocatorProvider(() => new BeginTransactionLocator(smContainer));
        }

        private static Container GetStructureMapContainer()
        {
            var container = new Container(c =>
            {
                c.For<IEventEntry>().Use<EventEntry>();
                c.For<IExceptionEntry>().Use<ExceptionEntry>();
                c.For<ILogger>().Use<Logger>().SelectConstructor(() => new Logger());
                c.For<ITenantConfigurationProvider>().Use<TenantConfigurationProvider>();
            });

            return container;
        }
    }

    internal class BeginTransactionLocator : ServiceLocatorImplBase
    {
        private readonly Container _container;

        public BeginTransactionLocator(Container container)
        {
            _container = container;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return string.IsNullOrWhiteSpace(key)
                ? _container.GetInstance(serviceType)
                : _container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }
    }

    internal class EndTransactionLocator : ServiceLocatorImplBase
    {
        private readonly Container _container;

        public EndTransactionLocator(Container container)
        {
            _container = container;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return string.IsNullOrWhiteSpace(key)
                ? _container.GetInstance(serviceType)
                : _container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}