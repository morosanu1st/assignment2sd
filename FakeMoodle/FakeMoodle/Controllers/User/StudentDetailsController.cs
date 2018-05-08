using BussinessContracts;
using BussinessContracts.Extensions;
using BussinessContracts.Models;
using FakeMoodle.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeMoodle.Controllers.User
{
    [System.Web.Http.RoutePrefix("api/user/details")]
    [Authorize(Roles = "Student")]
    public class StudentDetailsController : ApiController
    {
        private IStudentManagementService userService;        
        
        [Route("")]
        public UserModel Get()
        {
            var logged=((CustomPrincipal)RequestContext.Principal).LoggedUser;
            return logged.Trim();
        }
    }
}
