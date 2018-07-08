using BussinessContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessContracts.Models;
using DataContracts;
using BLL.Helpers;
using AutoMapper;
using DataContracts.Models;
using BussinessContracts.Extensions;

namespace BLL.Services
{
    public class StudentManagementService : IStudentManagementService
    {
        private IUserRepository userRepository;

        public StudentManagementService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public string CreateStudent(UserModel student)
        {
            var existing = userRepository.GetByEmail(student.Email);
            if (existing != null)
            {
                return null;
            }

            if (student.Group == 0 || student.Hobby == null || student.Name == null || student.Email == null)
            {
                return null;
            }

            var token = TokenGenerator.GenerateToken(128);
            student.PasswordHash = PasswordHasher.HashString(token);
            var dto = Mapper.Map<UserDto>(student);
            dto.IsAdmin = false;
            dto.Status = 0;
            dto.Id = 0;
            userRepository.Add(dto);
            userRepository.Save();

            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add(student.Email);
            message.Subject = "Registration token on fake moodle";
            message.From = new System.Net.Mail.MailAddress("register@fakemoodle.utcn");
            message.Body = "Your account has been created. Use the following token for the first login on the website";
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");

            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("chindrism96@gmail.com", "ghitza.ro");
            smtp.EnableSsl = true;

            smtp.Send(message);
            return token;
        }

        //public bool DeleteStudent(int studentId)
        //{
        //    var existing = userRepository.GetById(studentId);
        //    if (existing == null)
        //    {
        //        return false;
        //    }
        //    existing.Status = 2;
        //    userRepository.Edit(existing);
        //    userRepository.Save();
        //    return true;
        //}

        public bool DeleteStudent(int studentId)
        {
            var existing = userRepository.GetById(studentId);
            if (existing == null)
            {
                return false;
            }            
            userRepository.Delete(existing);
            userRepository.Save();
            return true;
        }

        public void EditStudent(UserModel student)
        {
            var v = userRepository.GetById(student.Id);
            v.Email = student.Email ?? v.Email;
            v.Group = student.Group == 0 ? v.Group : student.Group;
            v.Hobby = student.Hobby ?? v.Hobby;
            v.PasswordHash = student.PasswordHash ?? v.PasswordHash;
            v.Name = student.Name ?? v.Name;
            userRepository.Edit(v);
            userRepository.Save();
        }

        public IEnumerable<UserModel> GetAllStudents()
        {
            return Mapper.Map<UserDto[],IEnumerable<UserModel>>(userRepository.GetAll().Where(x => x.Status == 1 && x.IsAdmin == false).ToArray());
        }

        public UserModel GetStudent(int id)
        {
            return Mapper.Map<UserModel>(userRepository.GetById(id)).Trim();
        }

        public IEnumerable<UserModel> GetStudentsByGroup(int group)
        {
            return Mapper.Map<UserDto[], IEnumerable<UserModel>>(userRepository.GetGroup(group).Where(x => x.Status == 1 && x.IsAdmin == false).ToArray());
        }

        public IEnumerable<UserModel> SearchStudent(string q)
        {
            return Mapper.Map<UserDto[], IEnumerable<UserModel>>(userRepository.Search(q).Where(x => x.Status == 1 && x.IsAdmin == false).ToArray());
        }
    }
}
