using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Caliburn.Micro;

namespace WpfClient.Models
{
    public static class LoggerFactory
    {
        /// <summary>
        /// Creates logger instance.
        /// </summary>
        /// <returns>The ILog instance.</returns>
        public static ILog GetLogger(Type type)
        {
            Type loggerType;

            var loggerTypeName = ConfigurationManager.AppSettings["Logger"];
            if (!string.IsNullOrEmpty(loggerTypeName))
                loggerType = Type.GetType(loggerTypeName);
            else
                throw new NullReferenceException("Logger");

            if (loggerType == null)
                throw new ArgumentException(string.Format("Type {0} could not be found", loggerTypeName));

            return (ILog)Activator.CreateInstance(loggerType, type);
        }
    }
}