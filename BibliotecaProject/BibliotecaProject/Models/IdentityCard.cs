using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaProject.Models
{
    public class IdentityCard
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ID_user { get; set; }

        public string Type { get; set; }

        public string Emissary { get; set; }   

        public DateTime ExpirationDate { get; set; }

        [ForeignKey("ID_user")]
        public User User { get; set; } 

    }
}
