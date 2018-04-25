using AutoMapper;
using BussinessContracts;
using BussinessContracts.Models;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FakeMoodle.Controllers.Admin
{
    [System.Web.Http.RoutePrefix("api/admin/submissions")]
    public class SubmissionController : ApiController
    {
        private ISubmissionService submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            this.submissionService = submissionService;
        }

        [Route("")]
        public IEnumerable<SubmissionModel> Get()
        {
            return submissionService.GetAllSubmissions();
        }

        [Route("{id}")]
        public SubmissionModel Get(int id)
        {
            return submissionService.GetSubmisssion(id);
        }

        [Route("student/")]
        public IEnumerable<SubmissionModel> GetByStudent(int studentId)
        {
            return submissionService.GetSubmissionByStudent(studentId);
        }

        [Route("assignment/")]
        public IEnumerable<SubmissionModel> GetByAssignment(int assignmentId)
        {
            return submissionService.GetSubmissionByAssignment(assignmentId);
        }

        [Route("grade/{id}/{grade}")]
        public void Put(int id, int grade) 
        {
            submissionService.GradeSubmission(id, grade);
        }       
    }
}
