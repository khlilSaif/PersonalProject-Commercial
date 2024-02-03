using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace commercial.Services
{
    public interface IAuthenticationService
    {
        public IActionResult Authenticate(LoginRequest loginRequest);
        public IActionResult Logout(string email);
    }
}