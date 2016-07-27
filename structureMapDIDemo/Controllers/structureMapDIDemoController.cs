using System;
using System.Web.Http;
using Microsoft.Practices.ServiceLocation;
using structureMapDIDemo.Interface;

namespace structureMapDIDemo.Controllers
{
    public class StructureMapDiDemoController : ApiController
    {
        [HttpPost]
        public bool ValidateRequest()
        {
            try
            {
                var requestValidator = ServiceLocator.Current.GetInstance<IRequestValidator>();
                if (requestValidator.ValidateRequest())
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
    }
}
