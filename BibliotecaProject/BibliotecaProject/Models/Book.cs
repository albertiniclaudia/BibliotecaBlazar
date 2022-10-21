using System.ComponentModel.DataAnnotations;

namespace BibliotecaProject.Models
{
    public class Book
    {

        [Key]
        public Guid Id_book { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public string PublishingHouse { get; set; }

        public string TypeOfBooks { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(13)]
        public string ISBN { set; get; }


    }
}
