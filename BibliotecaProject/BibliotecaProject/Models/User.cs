using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class User
    {

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; } 

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public int Age { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string ResidentialAddress { get; set; }  

        public string FiscalCode { get; set; }


    }
}
