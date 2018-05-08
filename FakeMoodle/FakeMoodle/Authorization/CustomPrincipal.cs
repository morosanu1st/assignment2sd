using BussinessContracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace FakeMoodle.Authorization
{
    public class CustomPrincipal : GenericPrincipal
    {
        public UserModel LoggedUser { get; set; }

        public CustomPrincipal(IIdentity identity, string[] roles,UserModel user) : base(identity, roles)
        {
            LoggedUser = user;
        }
    }
}