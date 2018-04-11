using DAL.Contexts;
using DataContracts;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AttendanceRepository : GenericRepository<ModelContext, AttendanceDto>, IAttendanceRepository
    {
        public AttendanceDto GetSpecificAttendance(UserDto user,LaboratoryDto lab)
        {
            return Context.Attendances.Where(x=>x.UserId==user.Id&&lab.Id==x.LaboratoryId).FirstOrDefault();
        }

        public override void Add(AttendanceDto entity)
        {
            var existing = GetSpecificAttendance(entity.Student, entity.Lab);
            if(existing==null)
                base.Add(entity);
            else
            {
                entity.Id = existing.Id;
                base.Edit(entity);
            }
        }
    }
}
