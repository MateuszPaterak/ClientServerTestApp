using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using Autofac.Core;
using WebService.Models;

namespace WebService.Controllers
{
    public class AddUserController : ApiController
    {
        private IRepo _myRepo;
        public AddUserController(IRepo repo)
        {
            _myRepo = repo;
        }
        public IHttpActionResult PostAddUser(User user)
        {
            _myRepo.WriteUser(user);
            return Ok();
        }
    }
}
