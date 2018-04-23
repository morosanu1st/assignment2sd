using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessContracts
{
    public interface ISubmissionService
    {
        void AddSubmission(SubmissionModel submission);

        void GradeSubmission(int submissionId, int grade);

        void DeleteSubmission(SubmissionModel submission);

        SubmissionModel GetSubmisssion(int id);

        IEnumerable<SubmissionModel> GetSubmissionByAssignment(int assignmentId);

        IEnumerable<SubmissionModel> GetSubmissionByStudent(int studentId);

        SubmissionModel GetspecificSubmisssion(int assignmentId, int studentId);
    }
}
