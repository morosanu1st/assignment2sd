using System.Collections.Generic;
using DataContracts.Models;
using System.Linq;

namespace DataContracts
{
    public interface ISubmissionRepository : IGenericRepository<SubmissionDto>
    {
        IQueryable<SubmissionDto> GetByAssignment(AssignmentDto l);
        IQueryable<SubmissionDto> GetByStudent(UserDto s);
        SubmissionDto GetSpecificSubmission(UserDto s, AssignmentDto l);
        new void Add(SubmissionDto entity);
    }
}