using BussinessContracts;
using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeMoodle.Controllers.Admin
{
    [System.Web.Http.RoutePrefix("api/admin/laboratory")]

    public class LaboratoryController : ApiController
    {
        private ILaboratoryService labService;

        public LaboratoryController(ILaboratoryService labService)
        {
            this.labService = labService;
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

        [Route("date/{date}")]
        public LaboratoryModel GetByDate(string date)
        {
            DateTime d;
            if (!DateTime.TryParse(date, out d))
            {
                throw new Exception("invlid date format");
            }
            return labService.GetByDate(d);
        }

        [Route("number/{number}")]
        public LaboratoryModel GetByNumber(int number)
        {
            return labService.GetByNumber(number);
        }

        // POST: api/Laboratory
        [HttpPost]
        [Route("")]
        public void Post([FromBody]LaboratoryModel data)
        {
            labService.AddALaboratory(data);
        }

        // PUT: api/Laboratory/5
        [HttpPut]
        [Route("")]
        public void Put(int id, [FromBody]LaboratoryModel data)
        {
            data.Id = id;
            labService.EditLaboratory(data);
        }

        // DELETE: api/Laboratory/5
        [HttpDelete]
        [Route("")]
        public void Delete(int id)
        {
            labService.DeleteLaboratory(id);
        }

        [HttpGet]
        [Route("search/{q}")]
        public IEnumerable<LaboratoryModel> Search(string q)
        {
            return labService.SearchLaboratory(q);
        }
    }
}
