﻿using BussinessContracts;
using FakeMoodle.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FakeMoodle.Controllers.User
{
    public class LoginController : ApiController
    {
        private IAuthService authService;

        public LoginController(IAuthService authService)
        {
            this.authService = authService;
        }

        [System.Web.Http.HttpPost]
        public string Post([FromBody]LoginModel data)
        {

            return authService.Login(data.Email,PasswordHasher.HashString(data.PasswordHash));
        }
    }
}