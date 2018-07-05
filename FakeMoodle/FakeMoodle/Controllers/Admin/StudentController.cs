using BussinessContracts;
using BussinessContracts.Models;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeMoodle.Controllers.Admin
{
    [System.Web.Http.RoutePrefix("api/admin/student")]
    public class UserController : ApiController
    {
        private IUserManagementService studentService;
        private IAuthService authService;

        public UserController(IUserManagementService studentService, IAuthService authService)
        {
            this.studentService = studentService;
            this.authService = authService;
        }


        // GET: api/User
        [Route("")]
        public IEnumerable<UserModel> Get()
        {
            return studentService.GetAllUsers();
        }

        // GET: api/User/5
        [Route("{id}")]
        public UserModel Get(int id)
        {
            return studentService.GetUser(id);
        }

        [HttpPost]
        [Route("")]
        public string Post([FromBody]UserModel value)
        {
            return studentService.CreateUser(value);
        }

        [Route("")]
        [HttpPut]
        public void Put(int id, [FromBody]UserModel value)
        {
            value.Id = id;
            studentService.EditUser(value);
        }

        // DELETE: api/User/5
        [Route("")]
        [HttpDelete]
        public void Delete(int id)
        {
            studentService.DeleteUser(id);
        }

        [HttpGet]
        [Route("search/{q?}")]
        public IEnumerable<UserModel> Search(string q)
        {
            return studentService.SearchUser(q);
        }      
    }
}
