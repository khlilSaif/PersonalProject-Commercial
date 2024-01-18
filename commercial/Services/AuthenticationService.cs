 using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using commercial.RepositoryPattern;
using System.IdentityModel.Tokens.Jwt;
using dbProject.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using commercial.Secyrity;

namespace commercial.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IRepositoryPattern<AuthenticationToken> _authRepository;

        public AuthenticationService(IRepository<User> userRepository, IConfiguration configuration, IRepositoryPattern<AuthenticationToken> authRepository ){
            _userRepository = userRepository;
            _configuration = configuration;
            _authRepository = authRepository;
        }
        public IActionResult Authenticate(LoginRequest loginRequest){

            var user = _userRepository.GetByEmail(loginRequest.Email);
            
            if( user != null 
            && VerifyPassword(loginRequest.Password, user.HashedPassword))
            {
                var authValue = _authRepository.GetById(user.Id);
                
                var token = GenerateJwtToken(loginRequest.Email);
                var updatedAuth = new AuthenticationToken{
                    UserId = user.Id,
                    AuthToken = token
                };

                if(authValue == null ){
                   _authRepository.Add(updatedAuth);
                }
                else {
                    _authRepository.Update(updatedAuth);
                }
                
                return new OkObjectResult(new { AccessToken = token, 
                Message = "Login Successful" });
            }

            return new UnauthorizedObjectResult(new {Message = "Invalid Credentials"});
        }

        public IActionResult Logout(string email){
             var user = _userRepository.GetByEmail(email);
             if( user == null ){
                return new UnauthorizedObjectResult(new {Message = "No User with this Email"});
             }
             var authValue = _authRepository.GetById(user.Id);
             
             authValue.AuthToken = "saif";
             
             _authRepository.Update(authValue);
              
             return new OkObjectResult(new {Message = "Successful logout"});
        }
        
        private bool VerifyPassword(string password, string hashedPassword){
            byte[] hashedBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes) == hashedPassword;
        }

        private string GenerateJwtToken(string userEmail)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt"] ?? "");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, userEmail)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}