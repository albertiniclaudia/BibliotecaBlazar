using System.ComponentModel.DataAnnotations;

namespace BibliotecaProject.Models
{
    public class Parent
    {

        [Key]
        public Guid Id { get; set; }    

        public string Name { get; set; }

        public string PhoneNumber { get; set; } 

        public string Surname { get; set; }
        //public string Role { get; set; }

    }
}
