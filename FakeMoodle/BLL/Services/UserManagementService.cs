using AutoMapper;
using BLL.Helpers;
using BussinessContracts;
using BussinessContracts.Extensions;
using BussinessContracts.Models;
using DataContracts;
using DataContracts.Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class UserManagementService : IUserManagementService
    {
        private IUserRepository userRepository;

        public UserManagementService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public string CreateUser(UserModel user)
        {
            var existing = userRepository.GetByEmail(user.Email);
            if (existing != null)
            {
                return null;
            }

            if (user.Name == null || user.Email == null)
            {
                return null;
            }

            var token = TokenGenerator.GenerateToken(128);
            user.PasswordHash = PasswordHasher.HashString(token);
            var dto = Mapper.Map<UserDto>(user);
            dto.Role = user.Role;
            dto.Status = false;
            dto.Id = 0;
            userRepository.Add(dto);
            userRepository.Save();
            return token;
        }


        public bool DeleteUser(int userId)
        {
            var existing = userRepository.GetById(userId);
            if (existing == null)
            {
                return false;
            }
            userRepository.Delete(existing);
            userRepository.Save();
            return true;
        }

        public void EditUser(UserModel user)
        {
            var v = userRepository.GetById(user.Id);
            v.Email = user.Email ?? v.Email;
            v.PasswordHash = user.PasswordHash ?? v.PasswordHash;
            v.Name = user.Name ?? v.Name;
            userRepository.Edit(v);
            userRepository.Save();
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return Mapper.Map<UserDto[], IEnumerable<UserModel>>(userRepository.GetAll().Where(x => x.Status).ToArray());
        }

        public UserModel GetUser(int id)
        {
            return Mapper.Map<UserModel>(userRepository.GetById(id)).Trim();
        }

        public IEnumerable<UserModel> SearchUser(string q)
        {
            return Mapper.Map<UserDto[], IEnumerable<UserModel>>(userRepository.Search(q).Where(x => x.Status).ToArray());
        }
    }
}
