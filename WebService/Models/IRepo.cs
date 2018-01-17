using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Models
{
    public interface IRepo
    {
        void WriteUser(User user);
    }
}
