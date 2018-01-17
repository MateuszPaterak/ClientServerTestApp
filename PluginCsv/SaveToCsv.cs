using System.IO;
using System.Web;
using CsvHelper;
using PluginInterface;

namespace PluginCsv
{
    public class SaveToCsv : IWriteUserData
    {
        //private string Path = HttpContext.Current.Server.MapPath("~/") + "\\users.csv";
        //private const string FileName = "\\users.csv";

        public void Write(IUser user, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                using(StreamWriter sw = new StreamWriter(fs))
                {
                    var writer = new CsvWriter(sw);
                    writer.WriteRecord(user);
                }
        }
    }
}
