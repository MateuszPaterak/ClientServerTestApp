using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Caliburn.Micro;
using Caliburn.Micro.Logging;

namespace WebService.Models
{
    public class MyBootStrapper : BootstrapperBase 
    {
        static MyBootStrapper()
        {
            //LogManager.GetLog = type => new Log4netLogger(type);
            Caliburn.Micro.LogManager.GetLog = type => LoggerFactory.GetLogger(type);
        }
    }
}