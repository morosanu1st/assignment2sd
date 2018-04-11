using DataContracts.Models;

namespace DataContracts
{
    public interface IAttendanceRepository:IGenericRepository<AttendanceDto>
    {
        new void Add(AttendanceDto entity);
        AttendanceDto GetSpecificAttendance(UserDto user, LaboratoryDto lab);
    }
}