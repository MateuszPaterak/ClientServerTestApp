using System.Collections.Generic;
using PluginInterface;

namespace WebService.Models
{
    public class SaveToCollection : IWriteUserData
    {
        private List<IUser> _users = new List<IUser>();
        public void Write(IUser user, string path = null)
        {
            _users.Add(user);
        }
    }
}