using DAL.Contexts;
using DAL.Repositories;
using DataContracts;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeMoodle.Controllers.User
{
    [RoutePrefix("api/user/laboratory")]
    public class LaboratoryController : ApiController
    {
        private IUserRepository repo;

        public LaboratoryController(IUserRepository repo)
        {
            this.repo = repo;
        }
        // GET: api/Laboratory
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Laboratory/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("search/{q?}")]
        public string Search(string q = null)
        {
            repo.Add(new UserDto { UserName = "moro", PasswordHash = "asdasd", Email = "asldknnads", Name = "Chindriș Mihai", Group = 30431, Hobby = "Almost Dying" });
            repo.Save();
            repo.Edit(new UserDto { Id = 1, UserName = "morosanu", PasswordHash = "asdasd", Email = "asldknnads", Name = "Chindriș Mihai", Group = 30431, Hobby = "Almost Dying" });
            repo.Save();
            var res = repo.GetById(1);
            return "noneFound";
        }
    }

}
