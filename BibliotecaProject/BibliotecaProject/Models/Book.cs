using System.ComponentModel.DataAnnotations;

namespace BibliotecaProject.Models
{
    public class Book
    {

        [Key]
        public Guid Id_book { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ImageUrl { get; set; }

        public string PublishingHouse { get; set; }

        public int NumberOfCopy { get; set; }

        public string TypeOfBooks { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(13)]
        public string ISBN { set; get; }

        [Url]
        public string Image { get; set; }

        public ICollection<PositionBook> PositionBook { get; set; }


    }
}
