using PluginInterface;

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

        public void WriteUser(IUser user, string filePath)
        {    
            lock (m_SyncObject)
            {
                _saveData.Write(user, filePath);
            }
        
        }
    }
}