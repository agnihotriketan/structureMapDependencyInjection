using System;
using Microsoft.Practices.ServiceLocation;
using structureMapDIDemo.DI;
using structureMapDIDemo.Interface;
using Xunit;

namespace structureMapDIDemo.Tests
{ 
    public class StructureMapServiceLocatorTests
    {
        private readonly StructureMapServiceLocator _structureMapServiceLocator;

        public StructureMapServiceLocatorTests()
        {
            _structureMapServiceLocator = new StructureMapServiceLocator(StructureMapContainerProvider.GetContainer());
            ServiceLocator.SetLocatorProvider(() => _structureMapServiceLocator);
        }
         
        public void GetAllInstance_Success()
        {
            var instance = _structureMapServiceLocator.GetAllInstances<IRequestValidator>();
            Assert.NotNull(instance);
        }
        [Fact]
        public void GetInstanceByType_Success()
        {
            var instance = _structureMapServiceLocator.GetInstance(typeof (IRequestValidator));
            Assert.NotNull(instance);
        }

        [Fact]
        public void GetInstanceException_Fail()
        {
            Assert.ThrowsAny<Exception>(_structureMapServiceLocator.GetInstance<IDependancyException>);
        }

        [Fact]
        public void GetAllInstanceByType_Success()
        {
            var instance = _structureMapServiceLocator.GetAllInstances(typeof (IRequestValidator));
            Assert.NotNull(instance);
        }

        [Fact]
        public void GetInstance_Success()
        {
            var instance = _structureMapServiceLocator.GetInstance<IRequestValidator>();
            Assert.NotNull(instance);
        }
    }
}