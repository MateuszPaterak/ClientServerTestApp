using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using PostSharp.Aspects;

namespace WpfClient.Models
{
    [Serializable]
    public class MyAspect : OnMethodBoundaryAspect
    {
        //[NonSerialized]
        //private static readonly ILog logger = LogManager.GetLogger(
            //System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string methodName;

        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            methodName = method.DeclaringType.FullName + "." + method.Name;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //Console.WriteLine("Before Method " + args.Method.Name);
        logger.Info(null != this.methodName ? $" OnEntry: Method name: {this.methodName}" : "OnEntry");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            logger.Info(null != this.methodName ? $" OnExit: Method name: {this.methodName}" : "OnExit");
        }
    }
}
