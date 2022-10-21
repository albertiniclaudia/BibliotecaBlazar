using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class Parent
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; } 

        public string Surname { get; set; }

		public Guid Id_User { get; set; }

		[ForeignKey("Id_User")]
		public User User { get; set; }
	}
}
