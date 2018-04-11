using System.Collections.Generic;
using DataContracts.Models;

namespace DataContracts
{
    public interface ISubmissionRepository:IGenericRepository<SubmissionDto>
    {
        List<SubmissionDto> GetByLab(AssignmentDto l);
        List<SubmissionDto> GetByStudent(UserDto s);
        SubmissionDto GetSpecificSubmission(UserDto s, AssignmentDto l);
        new void Add(SubmissionDto entity);
    }
}