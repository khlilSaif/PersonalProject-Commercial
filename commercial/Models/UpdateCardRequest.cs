using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace commercial.Models
{
    public class UpdateCardRequest
    {
        public int UserId {get; set;}
        public int ProductId {get; set;}
    }
}