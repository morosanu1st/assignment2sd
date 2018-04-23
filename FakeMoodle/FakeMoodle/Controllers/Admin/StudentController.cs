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
    public class StudentController : ApiController
    {
        private IStudentManagementService studentService;
        private IAuthService authService;

        public StudentController(IStudentManagementService studentService, IAuthService authService)
        {
            this.studentService = studentService;
            this.authService = authService;
        }


        // GET: api/Student
        [Route("")]
        public IEnumerable<UserModel> Get()
        {
            return studentService.GetAllStudents();
        }

        // GET: api/Student/5
        [Route("{id}")]
        public UserModel Get(int id)
        {
            return studentService.GetStudent(id);
        }

        [HttpPost]
        [Route("")]
        public string Post([FromBody]UserModel value)
        {
            return studentService.CreateStudent(value);
        }

        [Route("")]
        [HttpPut]
        public void Put(int id, [FromBody]UserModel value)
        {
            value.Id = id;
            studentService.EditStudent(value);
        }

        // DELETE: api/Student/5
        [Route("")]
        [HttpDelete]
        public void Delete(int id)
        {
            studentService.DeleteStudent(id);
        }

        [HttpGet]
        [Route("search/{q?}")]
        public IEnumerable<UserModel> Search(string q)
        {
            return studentService.SearchStudent(q);
        }

        [HttpGet]
        [Route("group/{q?}")]
        public IEnumerable<UserModel> GetGroup(int group)
        {
            return studentService.GetStudentsByGroup(group);
        }

    }
}
