﻿using PluginInterface;

namespace WebService.Models
{
    public interface IWriteUserData
    {
        void Write(IUser user, string filePath);
    }
}
