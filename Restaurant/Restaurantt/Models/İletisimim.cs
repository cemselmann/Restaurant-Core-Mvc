using System.ComponentModel.DataAnnotations;

namespace Restaurantt.Models
{
	public class İletisimim
	{
		[Key]
		public int ID { get; set; }
		public string EMail { get; set; }
		public string Telefon{ get; set; }
		public string Adres { get; set; }
	}
}
