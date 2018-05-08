using BussinessContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeMoodle.Controllers.Auth
{
    [System.Web.Http.RoutePrefix("api/logout")]
    [Authorize]
    public class LogoutController : ApiController
    {
        private IAuthService authService;

        public LogoutController(IAuthService authService)
        {
            this.authService = authService;
        }

        [System.Web.Http.HttpPut]
        [Route("")]
        public HttpResponseMessage Put([FromBody]string data)
        {
            try
            {
                authService.LogUserOut(data);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
