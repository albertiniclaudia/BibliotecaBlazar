using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class LoanQueue
    {

        [Key]
        public Guid Id_loanQueue { get; set; }

        public Guid ID_book { get; set; }

        public Guid ID_user { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("ID_book")]
        public Book Book { get; set; }

        [ForeignKey("ID_user")]
        public Parent User { get; set; }

    }
}
