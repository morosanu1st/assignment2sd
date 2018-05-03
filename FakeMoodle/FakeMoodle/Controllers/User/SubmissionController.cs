using BussinessContracts;
using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeMoodle.Controllers.User
{
    [System.Web.Http.RoutePrefix("api/student/Submission")]
    public class SubmissionStudentController : ApiController
    {
        private ISubmissionService SubmissionService;

        public SubmissionStudentController(ISubmissionService SubmissionService)
        {
            this.SubmissionService = SubmissionService;
        }

        [Route("")]
        public IEnumerable<SubmissionModel> Get()
        {
            return SubmissionService.GetAllSubmissions();
        }

        [Route("")]
        [HttpPost]
        public void Post([FromBody]SubmissionModel data)
        {
            SubmissionService.AddSubmission(data);
        }

        [Route("")]
        [HttpPut]
        public void Put(int id, [FromBody]SubmissionModel data)
        {
            data.Id = id;
            SubmissionService.EditSubmission(data);
        }
    }
}
