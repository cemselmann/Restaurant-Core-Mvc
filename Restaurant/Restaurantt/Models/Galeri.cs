using System.ComponentModel.DataAnnotations;

namespace Restaurantt.Models
{
    public class Galeri
    {
        [Key]
        public int ID { get; set; }
    
        public string Image { get; set; }
    }
}
