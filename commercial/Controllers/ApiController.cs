namespace commercial.Controllers
{
    using commercial.Services;
    using dbProject.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {   
        private readonly IAuthenticationService _authenticationService;
        private readonly IRegistrationService _registrationService;
        
        public ApiController(IAuthenticationService authenticationService, IRegistrationService registrationService){
            _authenticationService = authenticationService;
            _registrationService = registrationService;
        }

        [HttpPost("Login")]
        public  IActionResult Login(LoginRequest longRequest)
        {
            return  _authenticationService.Authenticate(longRequest);
        }

        [HttpPost("Logout")]
        [Authorize]
        public  IActionResult Logout(string email)
        {
            return  _authenticationService.Logout(email);
        }

        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            return _registrationService.Register(user);
        }
    }
}