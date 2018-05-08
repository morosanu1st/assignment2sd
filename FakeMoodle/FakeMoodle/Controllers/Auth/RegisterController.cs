using BussinessContracts;
using FakeMoodle.ViewModel;
using System;
using System.Web.Http;

namespace FakeMoodle.Controllers.Auth
{
    [System.Web.Http.RoutePrefix("api/register")]
    public class RegisterController : ApiController
    {
        private IStudentManagementService studentService;
        private IAuthService authService;

        public RegisterController(IStudentManagementService studentService, IAuthService authService)
        {
            this.studentService = studentService;
            this.authService = authService;
        }

        [HttpPut]
        [Route("")]
        public string Put([FromBody]RegistrationModel data)
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