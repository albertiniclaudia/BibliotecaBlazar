using System.ComponentModel.DataAnnotations;

namespace BibliotecaProject.Models
{
    public class User : Parent
    {
      
        public string Role { get; set; }

        public int Age { get; set; }


        [MaxLength(15)]
        [DataType(DataType.Password)]
        public string Password { get; set;}

        [EmailAddress]
        public string Email { get; set; }

        public string ResidentialAddress { get; set; }  

        public string FiscalCode { get; set; }

        //public User Parent { get; set; }  

    }
}
