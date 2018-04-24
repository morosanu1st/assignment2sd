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
    [System.Web.Http.RoutePrefix("api/admin/attendance")]
    public class AttendanceController : ApiController
    {
        private IAttendanceService attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;
        }

        // GET: api/Attendance
        [Route("")]
        public IEnumerable<AttendanceModel> Get()
        {
            return attendanceService.GetAll();
        }

        // GET: api/Attendance/5
        [Route("{id}")]
        public AttendanceModel Get(int id)
        {
            return attendanceService.GetAttendance(id);
        }

        // POST: api/Attendance
        [Route("")]
        public void Post([FromBody]AttendanceViewModel data)
        {
            var attendance = new AttendanceModel { Lab = new LaboratoryModel { Id = data.LabId }, Student = new UserModel { Id = data.StudentId } };
            
            attendanceService.AddAttendance(attendance);
        }        

        // DELETE: api/Attendance/5
        [Route("")]
        public void Delete(int id)
        {
            attendanceService.DeleteAttendance(id);
        }

        [Route("laboratory/")]
        [HttpGet]
        public IEnumerable<AttendanceModel> GetByLab(int labId)
        {
            return attendanceService.GetByLaboratory(labId);
        }

        [Route("student/")]
        [HttpGet]
        public IEnumerable<AttendanceModel> GetByStudent(int studentId)
        {
            return attendanceService.GetByStudent(studentId);
        }

        [Route("student/{studentId}/lab/{labId}")]
        [HttpGet]
        public AttendanceModel GetSpecificAttendance(int studentId,int labId)
        {
            return attendanceService.GetSpecificAttendance(labId,studentId);
        }
    }
}
