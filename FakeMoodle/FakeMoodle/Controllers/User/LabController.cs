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
    [System.Web.Http.RoutePrefix("api/user/laboratory")]
    [Authorize(Roles ="Student")]
    public class LabController : ApiController
    {
        private ILaboratoryService labService;
        IAssignmentService assignmentService;

        public LabController(ILaboratoryService labService,IAssignmentService assignmentService)
        {
            this.labService = labService;
            this.assignmentService = assignmentService;
        }
        // GET: api/Laboratory
        [Route("")]
        public IEnumerable<LaboratoryModel> Get()
        {
            return labService.GetAll();
        }

        // GET: api/Laboratory/5
        [Route("{id}")]
        public LaboratoryModel Get(int id)
        {
            return labService.GetLaboratory(id);
        }

        [Route("date/")]
        public LaboratoryModel GetByDate(string date)
        {
            DateTime d;
            if (!DateTime.TryParse(date, out d))
            {
                throw new Exception("invlid date format");
            }
            var ret = labService.GetByDate(d);
            return ret;
        }

        [Route("number/")]
        public LaboratoryModel GetByNumber(int number)
        {
            return labService.GetByNumber(number);
        }

        [HttpGet]
        [Route("search/")]
        public IEnumerable<LaboratoryModel> Search(string q)
        {
            return labService.SearchLaboratory(q);
        }

        [Route("{labId}/assignments/")]
        [HttpGet]
        public IEnumerable<AssignmentModel> GetByLab(int labId)
        {
            return assignmentService.GetByLaboratory(labId);
        }
    }
}
