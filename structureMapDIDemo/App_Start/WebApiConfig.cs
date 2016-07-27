using System.Web.Http;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using structureMapDIDemo.DI;

namespace structureMapDIDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            var serializerSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;

            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.Converters.Add(new StringEnumConverter { CamelCaseText = true });

            var locatorProvider = new StructureMapServiceLocator(StructureMapContainerProvider.GetContainer());

            ServiceLocator.SetLocatorProvider(() => locatorProvider);
            config.DependencyResolver = new DependencyResolver();
        }
    }
}