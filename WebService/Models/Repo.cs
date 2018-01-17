using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Core;

namespace WebService.Models
{
    public class Repo : IRepo
    {
        private IWriteUserData _saveData;
        private object m_SyncObject = new object();

        public Repo(IWriteUserData saveData)
        {
            _saveData = saveData;
        }

        public void WriteUser(User user)
        {    
            lock (m_SyncObject)
            {
                _saveData.Write(user);
            }
        
        }
    }
}