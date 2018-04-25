using BussinessContracts;
using BussinessContracts.Models;
using FakeMoodle.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeMoodle.Controllers.Admin
{
    [System.Web.Http.RoutePrefix("api/admin/assignment")]
    public class AssignmentController : ApiController
    {
        private IAssignmentService assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            this.assignmentService = assignmentService;
        }

        // GET: api/Assignments
        [Route("")]
        public IEnumerable<AssignmentModel> Get()
        {
            return assignmentService.GetAllAssignments();
        }

        // GET: api/Assignments/5
        [Route("{id}")]
        public AssignmentModel Get(int id)
        {
            return assignmentService.GetAssignment(id);
        }

        // POST: api/Assignments
        [Route("")]
        [HttpPost]
        public void Post([FromBody]AssignmentViewModel data)
        {
            if(data.DueDate < DateTime.Now)
            {
                throw new Exception("Wrong date input, date must match format yyyy-MM-dd");
            }
            assignmentService.AddAssignment(new AssignmentModel { Laboratory = new LaboratoryModel { Id = data.LaboratoryId }, Name = data.Name, DueDate = data.DueDate, Description = data.Description });
        }

        // PUT: api/Assignments/5
        [Route("")]
        [HttpPut]
        public void Put(int id, [FromBody]AssignmentViewModel data)
        {
            if (data.DueDate<DateTime.Now)
            {
                throw new Exception("Wrong date input, date must match format yyyy-MM-dd");
            }
            assignmentService.EditAssignment(new AssignmentModel { Id = id, Laboratory = new LaboratoryModel { Id = data.LaboratoryId }, Name = data.Name, DueDate = data.DueDate, Description = data.Description });
        }

        // DELETE: api/Assignments/5
        [Route("")]
        [HttpDelete]
        public void Delete(int id)
        {
            assignmentService.DeleteAssignment(id);
        }

        [Route("search/")]
        [HttpGet]
        public IEnumerable<AssignmentModel> Search(string q)
        {
            return assignmentService.Search(q);
        }

        [Route("bylab/")]
        [HttpGet]
        public IEnumerable<AssignmentModel> GetByLab(int labId)
        {
            return assignmentService.GetByLaboratory(labId);
        }

    }
}
