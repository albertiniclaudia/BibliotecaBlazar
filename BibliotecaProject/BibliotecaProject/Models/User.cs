using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }    

        public string Name { get; set; }

        public string PhoneNumber { get; set; } 

        public string Surname { get; set; }
      
        public string Role { get; set; }

        public int Age { get; set; }

        public Guid Id_Parent { get; set; }

        [MaxLength(15)]
        [DataType(DataType.Password)]
        public string Password { get; set;}

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string ResidentialAddress { get; set; }  

        public string FiscalCode { get; set; }

        //public User Parent { get; set; }  

    }
}
