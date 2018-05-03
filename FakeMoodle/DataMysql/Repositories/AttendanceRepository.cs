using DataMySql.Contexts;
using DataContracts;
using DataContracts.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMySql.Repositories
{
    public class AttendanceRepositorySql : GenericRepositorySql<MysqlContext, AttendanceDto>, IAttendanceRepository
    {
        public AttendanceDto GetSpecificAttendance(UserDto user, LaboratoryDto lab)
        {
            return Context.Attendances.Include(x => x.Lab).Include(x => x.Student).Where(x => x.UserId == user.Id && lab.Id == x.LaboratoryId).FirstOrDefault<AttendanceDto>();
        }

        public override IQueryable<AttendanceDto> GetAll()
        {
            return Context.Attendances.Include(x => x.Lab).Include(x => x.Student);
        }

        public override AttendanceDto GetById(int id)
        {
            return Context.Attendances.Include(x => x.Lab).Include(x => x.Student).Where(x=>x.Id==id).FirstOrDefault();
        }

        public override void Add(AttendanceDto entity)
        {
            var existing = GetSpecificAttendance(new UserDto { Id = entity.UserId }, new LaboratoryDto { Id = entity.LaboratoryId });
            if (existing == null)
                base.Add(entity);
        }
    }
}
