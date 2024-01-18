using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dbProject.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}
        public string ProdcutName {get; set;} = null!;
        public string Price {get; set;} = null!;
        public int Availabilty {get; set;}
    }
}