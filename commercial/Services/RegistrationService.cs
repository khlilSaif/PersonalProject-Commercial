using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commercial.RepositoryPattern;
using dbProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace commercial.Services
{
        public class RegistrationService : IRegistrationService
    {
        private readonly IRepositoryPattern<User> _userRepositoryPattern;
        private readonly IRepository<User> _userRepository;

        public RegistrationService(IRepositoryPattern<User> userRepositoryPattern, IRepository<User> userRepository)
        {
            _userRepositoryPattern = userRepositoryPattern;
            _userRepository = userRepository;
        }

        public IActionResult Register(User user)
        {
            var doesUserExist = _userRepository.GetByEmail(user.Email) != null;

            if (doesUserExist)
            {
                return new UnauthorizedObjectResult(new { Message = "Email exists" });
            }

            try
            {   
                _userRepositoryPattern.Add(user);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it more gracefully
                return new UnauthorizedObjectResult(new { Message = "Registration failed" });
            }

            return new OkObjectResult(new { Message = "Registration Successful" });
        }
    }
}