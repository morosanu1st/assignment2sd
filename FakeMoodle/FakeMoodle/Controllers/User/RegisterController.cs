using BussinessContracts;
using BussinessContracts.Models;
using FakeMoodle.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FakeMoodle.Controllers.User
{
    [System.Web.Http.RoutePrefix("api/user/register")]
    public class RegisterController : ApiController
    {
        private IStudentManagementService studentService;
        private IAuthService authService;

        public RegisterController(IStudentManagementService studentService, IAuthService authService)
        {
            this.studentService = studentService;
            this.authService = authService;
        }

        [System.Web.Http.HttpPut]
        public string Post([FromBody]RegistrationModel data)
        {
            try
            {
                return authService.FirstLogin(data.Email, PasswordHasher.HashString(data.Token), PasswordHasher.HashString(data.PasswordHash));
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}