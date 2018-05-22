using AutoMapper;
using BLL.Helpers;
using BussinessContracts;
using BussinessContracts.Models;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository userRepo;

        public AuthService(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        public string FirstLogin(string email, string token, string passwordHash)
        {
            if (email == null || token == null || passwordHash == null)
            {
                return null;
            }
            var toRegister = userRepo.GetByEmail(email);
            if (toRegister?.PasswordHash != token || toRegister?.Status != 0)
            {
                return null;
            }
            toRegister.PasswordHash = passwordHash;
            toRegister.Status = 1;
            userRepo.Edit(toRegister);
            var authToken = TokenGenerator.GenerateToken(512);
            userRepo.SetToken(toRegister.Id,authToken);
            userRepo.Save();

            //generate and register auth token here boiii
            return authToken;
        }

        public string Login(string email, string passwordHash)
        {
            if (email == null || passwordHash == null)
            {
                return null;
            }
            var toRegister = userRepo.GetByEmail(email);
            if (toRegister == null || toRegister.PasswordHash != passwordHash || toRegister.Status != 1)
            {
                return null;
            }
            var authToken = TokenGenerator.GenerateToken(512);
            userRepo.SetToken(toRegister.Id, authToken);
            userRepo.Save();

            //generate and register auth token here boiii
            return authToken;
        }

        public void LogUserOut(string token)
        {
            var user=userRepo.GetByToken(token);
            if (user == null)
            {
                throw new Exception("invlaid token");
            }
            user.Token = null;
            userRepo.Edit(user);
            userRepo.Save();
        }

        public UserModel ValidateToken(string token)
        {
            return Mapper.Map<UserModel>(userRepo.GetByToken(token));
        }
    }
}
