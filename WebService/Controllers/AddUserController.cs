using System.Web;
using System.Web.Http;
using PluginInterface;
using WebService.Models;

namespace WebService.Controllers
{
    public class AddUserController : ApiController
    {
        private IRepo _myRepo;
        private string _filePath;
        public AddUserController(IRepo repo, string filePath =null)
        {
            _myRepo = repo;
            if (string.IsNullOrEmpty(filePath))
            {
                _filePath = HttpContext.Current.Server.MapPath("~/") + "users.csv";
            }
            else
            {
                _filePath = filePath;
            }
        }
        public IHttpActionResult PostAddUser(IUser user)
        {
            _myRepo.WriteUser(user, _filePath);
            return Ok();
        }
    }
}
