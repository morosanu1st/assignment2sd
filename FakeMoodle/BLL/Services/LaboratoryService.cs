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

namespace BLL.Services
{
    public class LaboratoryService : ILaboratoryService
    {
        private ILaboratoryRepository labRepo;

        public LaboratoryService(ILaboratoryRepository labRepo)
        {
            this.labRepo = labRepo;
        }

        public void AddALaboratory(LaboratoryModel laboratory)
        {
            if (labRepo.GetByDate(laboratory.Date) != null || labRepo.GetByNumber(laboratory.Number) != null)
            {
                throw new Exception("laboratory already exists");
            }
            laboratory.Id = 0;
            labRepo.Add(Mapper.Map<LaboratoryDto>(laboratory));
            labRepo.Save();
        }

        public void DeleteLaboratory(int id)
        {
            labRepo.Delete(labRepo.GetById(id));
        }

        public void EditLaboratory(LaboratoryModel laboratory)
        {
            var existing = labRepo.GetById(laboratory.Id);
            if (existing.Number != laboratory.Number)
            {
                if (labRepo.GetByNumber(laboratory.Number) == null)
                {
                    existing.Number = laboratory.Number;
                }
                else
                {
                    throw new Exception("There already exists a lab with that number");
                }
            }
            if (existing.Date != laboratory.Date)
            {
                if (labRepo.GetByDate(laboratory.Date) == null)
                {
                    if (laboratory.Date < DateTime.Now)
                    {
                        throw new Exception("Date must be in the future");
                    }
                    existing.Date = laboratory.Date;
                }
                else
                {
                    throw new Exception("There already exists a lab with that Date");
                }
            }
            existing.Title = laboratory.Title ?? existing.Title;
            existing.Curricula = laboratory.Curricula ?? existing.Curricula;
            existing.Description = laboratory.Description ?? existing.Description;
            labRepo.Edit(existing);
            labRepo.Save();
        }

        public IEnumerable<LaboratoryModel> GetAll()
        {
            return Mapper.Map<LaboratoryDto[], IEnumerable<LaboratoryModel>>(labRepo.GetAll().ToArray());
        }

        public LaboratoryModel GetByDate(DateTime date)
        {
            return Mapper.Map<LaboratoryModel>(labRepo.GetByDate(date));
        }

        public LaboratoryModel GetByNumber(int number)
        {
            return Mapper.Map<LaboratoryModel>(labRepo.GetByNumber(number));
        }

        public LaboratoryModel GetLaboratory(int id)
        {
            return Mapper.Map<LaboratoryModel>(labRepo.GetById(id));
        }

        public IEnumerable<LaboratoryModel> SearchLaboratory(string q)
        {
            return Mapper.Map<LaboratoryDto[], IEnumerable<LaboratoryModel>>(labRepo.Search(q).ToArray());
        }
    }
}
