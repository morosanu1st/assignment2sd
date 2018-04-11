using DataContracts;
using DataContracts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Tests
{
    [TestClass()]
    public class UserRepositoryTests
    {
        private UserRepository repo = new UserRepository();



        [TestMethod()]
        public void GetUserByIdTest()
        {
            repo.Add(new UserDto { UserName = "moro", PasswordHash = "asdasd", Email = "asldknnads", Name = "Chindriș Mihai", Group = 30431, Hobby = "Almost Dying" });
            var res = repo.Search("moro");
            Assert.AreNotEqual(res, null);
        }


    }
}