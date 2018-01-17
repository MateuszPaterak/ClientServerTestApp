using PluginInterface;

namespace WebService.Models
{
    public interface IRepo
    {
        void WriteUser(IUser user, string filePath);
    }
}
