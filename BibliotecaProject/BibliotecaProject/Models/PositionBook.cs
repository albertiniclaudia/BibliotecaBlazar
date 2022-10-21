using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class PositionBook
    {
        [Key]
        public Guid Id_positionBook { get; set; }

        public Guid ID_book { get; set; }

        public string Room { get; set; }

        public string Rack { get; set; }

        public string Shelf { get; set; }

        public string Place { get; set; }


        [ForeignKey("ID_book")]
        public Book Book { get; set; }

    }
}
