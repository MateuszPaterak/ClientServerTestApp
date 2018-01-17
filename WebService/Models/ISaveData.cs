using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models
{
    public interface IWriteUserData
    {
        void Write(User user);
    }
}
