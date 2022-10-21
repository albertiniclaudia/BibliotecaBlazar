using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class Loan
    {
        [Key]
        public Guid Id_loan { get; set; }

        [Required]
        public DateTime RentalStartData { get; set; }

        [Required] 
        public DateTime RentalEndData { get; set; }

        
        public Guid ID_Book { get; set; }

        public Guid ID_user { get; set; }

        [ForeignKey("ID_Book")]
        public Book Book { get; set; }

        [ForeignKey("ID_user")]
        public User User { get; set; }

    }
}
