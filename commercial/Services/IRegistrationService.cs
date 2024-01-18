using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dbProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace commercial.Services
{
    public interface IRegistrationService
    {
        public IActionResult Register(User user);
    }
}