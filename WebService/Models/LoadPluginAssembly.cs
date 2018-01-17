using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;

namespace WebService.Models
{
    public class LoadPluginAssembly
    {
        public static IEnumerable<Assembly> LoadPlugin(string loadingInterfaceName)
        {
            //List<Assembly> assemblyToAdd = new List<Assembly>();
            
            var fullPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            DirectoryInfo di = new DirectoryInfo(fullPath);

            foreach (FileInfo fi in di.GetFiles("Plugin*.dll"))
            {
                Assembly pluginAssembly = Assembly.LoadFrom(fi.FullName);
                foreach (Type pluginType in pluginAssembly.GetExportedTypes().Where(t => t.GetInterface(loadingInterfaceName) != null))
                {
                    //if (null != pluginType.GetInterface(loadingInterfaceName))
                    //{
                        yield return pluginAssembly;
                        //          assemblyToAdd.Add(pluginAssembly);
                    //}
                }
            }
            //return assemblyToAdd;
        }
    }
}