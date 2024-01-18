using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace commercial
{
    public class LoginRequest
    {
        public string Password {get; set;} = null!;
        public string Email {get; set;} = null!;
    }
}