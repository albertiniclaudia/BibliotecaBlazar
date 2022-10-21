using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class Parent
    {

        [Key]
        public Guid Id { get; set; }

        public Guid ID_user { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; } 

        public string Surname { get; set; }

        [ForeignKey("ID_user")]
        public User User { get; set; }

    }
}
