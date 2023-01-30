using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurantt.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; } 
        [Required]  
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        public bool OzelMenu { get; set; }
        public double Price{ get; set; }

        
        public int KategoriID { get; set; }

        [ForeignKey("KategoriID")]
        public Kategori Kategori { get; set; }
    }
}
