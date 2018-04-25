using AutoMapper;
using BLL.Extensions;
using BussinessContracts;
using BussinessContracts.Models;
using DataContracts;
using DataContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AssignmentService : IAssignmentService
    {
        private IAssignmentRepository assignmentRepository;
        private ILaboratoryRepository laboratoryRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository, ILaboratoryRepository laboratoryRepository)
        {
            this.assignmentRepository = assignmentRepository;
            this.laboratoryRepository = laboratoryRepository;
        }

        public void AddAssignment(AssignmentModel assignment)
        {
            if (laboratoryRepository.GetById(assignment.Laboratory.Id) == null)
            {
                throw new Exception("lab not present");
            }
            assignmentRepository.Add(Mapper.Map<AssignmentDto>(assignment));
            assignmentRepository.Save();
        }

        public void DeleteAssignment(int assignmentId)
        {
            assignmentRepository.Delete(assignmentRepository.GetById(assignmentId));
            assignmentRepository.Save();
        }

        public void EditAssignment(AssignmentModel assignment)
        {
            var toUpdate = assignmentRepository.GetById(assignment.Id);
            if (laboratoryRepository.GetById(assignment.Laboratory.Id) == null)
            {
                if (assignment.Laboratory.Id != 0)
                {
                    throw new Exception("lab not present");
                }
            }

            if (toUpdate != null)
            {
                toUpdate.Name = assignment.Name ?? toUpdate.Name;
                toUpdate.LaboratoryId = assignment.Laboratory.Id != 0 ? assignment.Laboratory.Id : toUpdate.LaboratoryId;
                toUpdate.Description = assignment.Description ?? toUpdate.Description;
                toUpdate.DueDate = assignment.DueDate.Date <= DateTime.Now.Date ? toUpdate.DueDate : assignment.DueDate;
                laboratoryRepository.Save();
            }
        }

        public IEnumerable<AssignmentModel> GetAllAssignments()
        {
            return Mapper.Map<AssignmentDto[],IEnumerable<AssignmentModel>>(assignmentRepository.GetAll().ToArray()).Select(x=>x.Trim());
        }

        public AssignmentModel GetAssignment(int id)
        {
            return Mapper.Map<AssignmentModel>(assignmentRepository.GetById(id)).Trim();
        }

        public IEnumerable<AssignmentModel> GetByLaboratory(int labId)
        {
            return Mapper.Map<AssignmentDto[], IEnumerable<AssignmentModel>>(laboratoryRepository.GetById(labId).Assignments.ToArray()).Select(x => x.Trim());
        }

        public IEnumerable<AssignmentModel> Search(string q)
        {
            return Mapper.Map<AssignmentDto[], IEnumerable<AssignmentModel>>(assignmentRepository.Search(q).ToArray()).Select(x => x.Trim());
        }
    }
}
