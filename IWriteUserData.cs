using System;

namespace PluginInterfaces.Write
{
    public interface IWriteUserData
    {
        void Write(User user, string filePath);
    }
}
