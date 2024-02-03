using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace commercial.Secyrity
{
    public class AuthenticationToken
    {
        [Key]
        public int UserId {get; set;}
        public string AuthToken {get; set;} = null!;
    }
}