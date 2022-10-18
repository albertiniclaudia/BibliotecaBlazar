using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class PurchaseQueue
    {

        [Key]
        public Guid Id_purchaseQueue  { get; set; }

        public Guid ID_user { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }


        [MaxLength(100)]
        public string? Author { get; set; }


        [MaxLength(100)]
        public string? PublishingHouse { get; set; }


        [MaxLength(13)]
        public string? ISBN { set; get; }

        [ForeignKey("ID_user")]
        public Parent Parent { get; set; }

    }
}
