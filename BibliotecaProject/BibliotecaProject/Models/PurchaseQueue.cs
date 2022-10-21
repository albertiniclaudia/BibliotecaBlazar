using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class PurchaseQueue
    {

        [Key]
        public Guid Id_purchaseQueue  { get; set; }

        public Guid ID_user { get; set; }


        public string Title { get; set; }


        public string? Author { get; set; }


        public string? PublishingHouse { get; set; }


        public string? ISBN { get; set; }

        [ForeignKey("ID_user")]
        public User User { get; set; }

    }
}
