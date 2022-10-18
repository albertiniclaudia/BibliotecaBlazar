using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class PositionBook
    {
        [Key]
        public Guid Id_positionBook { get; set; }


        public Guid ID_book;

        [Required]
        [MaxLength(12)]
        public string Room { get; set; }

        [Required]
        [MaxLength(12)]
        public string Rack { get; set; }

        [Required]
        [MaxLength(12)]
        public string Shelf { get; set; }

        [Required]
        [MaxLength(12)]
        public string Place { get; set; }


        [ForeignKey("ID_book")]
        public Book Book { get; set; }

    }
}
