using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class IdentityCard
    {
        [Key]
        public Guid Id { get; set; }

        public Guid Id_user { get; set; }

        public string Type { get; set; }

        public string Emissary { get; set; }   

        public DateTime ExpirationDate { get; set; }

        [ForeignKey("Id_user")]
        public Parent Parent { get; set; } 

    }
}
