using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Caliburn.Micro;

namespace WebService.Models
{
    public static class LogManager
    {
        static readonly ILog NullLogInstance = new NullLog();

        /// <summary>
        /// Creates an <see cref="ILog"/> for the provided type.
        /// </summary>
        public static Func<Type, ILog> GetLog = type => NullLogInstance;

        private class NullLog : ILog
        {
            public void Info(string format, params object[] args) { }
            public void Warn(string format, params object[] args) { }
            public void Error(Exception exception) { }
        }
    }
}