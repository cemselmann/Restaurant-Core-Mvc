using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurantt.Models
{
	public class İletisim
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Name { get; set; }
        [Required]
        public string EMail { get; set; }
		[Required]
		public string  Telefon { get; set; }

		[Required]
		public string Mesaj { get; set; }
		public DateTime Tarih{ get; set; }
	}
}
