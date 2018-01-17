using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using WebService.Models;

namespace PluginCsv
{
    public class SaveToCsv : IWriteUserData
    {
        public string Path { get; set; } = @"D:";
        //public string Path { get; set; } = @"D:\ProjectsVs\RecruitmentApp\WebService";
        //public string Path { get; set; } = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private const string FileName = "\\users.csv";

        public void Write(User user)
        {
            using (FileStream fs = new FileStream(Path + FileName, FileMode.Append, FileAccess.Write))
                using(StreamWriter sw = new StreamWriter(fs))
                {
                    var writer = new CsvWriter(sw);
                    //writer.WriteHeader(typeof(User));
                    writer.WriteRecord(user);
                }
        }
    }
}
