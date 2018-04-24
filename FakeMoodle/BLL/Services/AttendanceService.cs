using BussinessContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessContracts.Models;
using DataContracts;
using AutoMapper;
using DataContracts.Models;
using BLL.Extensions;

namespace BLL.Services
{
    public class AttendanceService : IAttendanceService
    {
        private IAttendanceRepository attendanceRepository;
        private ILaboratoryRepository laboratoryRepository;
        private IUserRepository userRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository, ILaboratoryRepository laboratoryRepository, IUserRepository userRepository)
        {
            this.attendanceRepository = attendanceRepository;
            this.laboratoryRepository = laboratoryRepository;
            this.userRepository = userRepository;
        }

        public void AddAttendance(AttendanceModel attendance)
        {
            var lab = laboratoryRepository.GetById(attendance.Lab.Id);
            var student = userRepository.GetById(attendance.Student.Id);
            if (student == null)
            {
                throw new Exception("no student with such id");
            }
            if (lab == null)
            {
                throw new Exception("no lab wiht such id");
            }
            attendanceRepository.Add(new AttendanceDto { LaboratoryId = lab.Id, UserId = student.Id });
            attendanceRepository.Save();
        }

        public void DeleteAttendance(int attendanceId)
        {
            attendanceRepository.Delete(attendanceRepository.GetById(attendanceId));
            attendanceRepository.Save();
        }

        public IEnumerable<AttendanceModel> GetAll()
        {
            return Mapper.Map<AttendanceDto[], IEnumerable<AttendanceModel>>(attendanceRepository.GetAll().ToArray()).Select(x => x.Trim());
        }

        public AttendanceModel GetAttendance(int id)
        {
            return Mapper.Map<AttendanceModel>(attendanceRepository.GetById(id)).Trim();
        }

        public IEnumerable<AttendanceModel> GetByLaboratory(int labId)
        {
            var ret = Mapper.Map<AttendanceDto[], IEnumerable<AttendanceModel>>(laboratoryRepository.GetById(labId).Attendances.ToArray());
            return ret.Select(x => x.Trim());
        }

        public IEnumerable<AttendanceModel> GetByStudent(int studentId)
        {
            return Mapper.Map<AttendanceDto[], IEnumerable<AttendanceModel>>(userRepository.GetById(studentId).Attendances.ToArray()).Select(x => x.Trim());
        }

        public AttendanceModel GetSpecificAttendance(int labId, int studentId)
        {
            return Mapper.Map<AttendanceModel>(attendanceRepository.GetSpecificAttendance(new UserDto { Id = studentId }, new LaboratoryDto { Id = labId })).Trim();
        }
    }
}
