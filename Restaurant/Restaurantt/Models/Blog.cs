using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurantt.Models
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Name { get; set; }
       
        [Required]
        public string EMail{ get; set; }
        public string Image{ get; set; }
        public bool Onay { get; set; }
      
        [Required]
        public string  Mesaj { get; set; }
        public DateTime Tarih { get; set; }
    }
}
