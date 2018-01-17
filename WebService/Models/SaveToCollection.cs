using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class SaveToCollection : IWriteUserData
    {
        private List<User> _users = new List<User>();
        public void Write(User user)
        {
            _users.Add(user);
        }
    }
}