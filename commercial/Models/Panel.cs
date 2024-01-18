using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dbProject.Models
{
    public class Panel
    {
        [Key]
        public int UserId { get; set; }
        public List<int> ProductIds { get; set; } = new List<int>();

        public int TotalAmount {get; set;}
    }

}