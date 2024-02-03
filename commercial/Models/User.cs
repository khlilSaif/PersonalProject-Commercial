using System.Data;
using System.ComponentModel.DataAnnotations;

namespace dbProject.Models
{
    public class User
    {
        public User(string firstName)
        {
            this.FirstName = firstName;
        }
        [Key]
        public int Id {get; set;}
        public string FirstName {get; set;} = null!;
        public string FastName {get; set;} = null!;
        public string Email {get; set;} = null!;
        public string HashedPassword {get; set;} = null!;
    }
}