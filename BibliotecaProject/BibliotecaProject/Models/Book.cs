using System.ComponentModel.DataAnnotations;

namespace BibliotecaProject.Models
{
    public class Book
    {

        [Key]
        public Guid Id_book { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string PublishingHouse { get; set; }

        [Required]
        [Range(1,100)]
        public int NumberOfCopy { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeOfBooks { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [MaxLength(13)]
        public string ISBN { set; get; }

        [Url]
        public string Image { get; set; }

        public ICollection<PositionBook> PositionBook { get; set; }


    }
}
