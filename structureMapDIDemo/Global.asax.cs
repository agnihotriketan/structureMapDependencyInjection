using System;
using System.Web;
using System.Web.Http;

namespace structureMapDIDemo
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
           //Log Errros
        }
    }
}