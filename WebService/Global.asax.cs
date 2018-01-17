using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Caliburn.Micro;
using Caliburn.Micro.Logging.log4net;
using log4net;
using log4net.Config;
using WebService.AutofacConf;
using WebService.Models;

namespace WebService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        //private static readonly Caliburn.Micro.ILog logger = Caliburn.Micro.LogManager.GetLog(
            //System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            var pluginAssembly = LoadPluginAssembly.LoadPlugin(typeof(IWriteUserData).Name);
            if(null != pluginAssembly)
                AutofacWebapiConfig.AssemblyToLoad.AddRange(pluginAssembly);

            AutofacWebapiConfig.Run();
            //logger.Info("save this test text");
            
        }
    }
}
