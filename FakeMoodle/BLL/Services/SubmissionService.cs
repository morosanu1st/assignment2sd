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
    public class SubmissionService : ISubmissionService
    {
        private ISubmissionRepository submissionRepository;
        private IAssignmentRepository assignmentRepository;
        private IUserRepository userRepository;

        public SubmissionService(ISubmissionRepository submissionRepository,IAssignmentRepository assignmentRepository,IUserRepository userRepository)
        {
            this.submissionRepository = submissionRepository;
            this.assignmentRepository = assignmentRepository;
            this.userRepository = userRepository;
        }

        public void AddSubmission(SubmissionModel submission)
        {
            var assignment = assignmentRepository.GetById(submission.Assignment.Id);
            if (assignment.DueDate < DateTime.Now)
            {
                throw new Exception("Deadline has passed for this assignment");
            }
            
            if (assignment==null)
            {
                throw new Exception("the assignmwnt does not exist");
            }
            if (userRepository.GetById(submission.Student.Id) == null)
            {
                throw new Exception("the student does not exist");
            }

            var newSubmission = Mapper.Map<SubmissionDto>(submission);
            newSubmission.StudentId = submission.Student.Id;
            newSubmission.AssignmentId = submission.Assignment.Id;           
            var existing = submissionRepository.GetSpecificSubmission(newSubmission.Student,newSubmission.Assignment);
            if (existing!=null)
            {
                throw new Exception("Assignment already submited");
            }
                submissionRepository.Add(newSubmission);
            submissionRepository.Save();
        }

        public void DeleteSubmission(SubmissionModel submission)
        {
            var existimg = submissionRepository.GetById(submission.Id);
            if(existimg==null)
            {
                throw new Exception("the submission does not exist");
            }
            submissionRepository.Delete(existimg);
            submissionRepository.Save();
        }

        public bool EditSubmission(SubmissionModel submissionModel)
        {
            var existing = submissionRepository.GetById(submissionModel.Id);
            if (existing == null)
            {
                throw new Exception("Submission not present");
            }
            if (existing.Attempt >= 3)
            {
                throw new Exception("No more attempts");
            }
            submissionRepository.Add(Mapper.Map<SubmissionDto>(submissionModel));
            submissionRepository.Save();
            return true;
        }

        public IEnumerable<SubmissionModel> GetAllSubmissions()
        {
            return Mapper.Map<SubmissionDto[], IEnumerable<SubmissionModel>>(submissionRepository.GetAll().ToArray()).Select(x => x.Trim());
        }

        public SubmissionModel GetspecificSubmisssion(int assignmentId, int studentId)
        {
            return Mapper.Map<SubmissionModel>(submissionRepository.GetSpecificSubmission(new UserDto { Id = studentId }, new AssignmentDto { Id = assignmentId })).Trim();
        }

        public IEnumerable<SubmissionModel> GetSubmissionByAssignment(int assignmentId)
        {
            return Mapper.Map<SubmissionDto[], IEnumerable<SubmissionModel>>(submissionRepository.GetByAssignment(new AssignmentDto { Id = assignmentId }).ToArray()).Select(x => x.Trim());
        }

        public IEnumerable<SubmissionModel> GetSubmissionByStudent(int studentId)
        {
            return Mapper.Map<SubmissionDto[], IEnumerable<SubmissionModel>>(submissionRepository.GetByStudent(new UserDto { Id = studentId }).ToArray()).Select(x => x.Trim());
        }

        public SubmissionModel GetSubmisssion(int id)
        {
            return Mapper.Map<SubmissionModel>(submissionRepository.GetById(id)).Trim();
        }

        public void GradeSubmission(int submissionId, int grade)
        {
            var existing = submissionRepository.GetById(submissionId);
            if (existing == null)
            {
                throw new Exception("submission not present");
            }
            if (grade < 0 || grade > 100)
            {
                throw new Exception("invalid grade");
            }
            existing.Grade = grade;
            submissionRepository.Edit(existing);

            submissionRepository.Save();
        }
    }
}
