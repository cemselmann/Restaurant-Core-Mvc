using System.ComponentModel.DataAnnotations;

namespace Restaurantt.Models
{
	public class Hakkımızda
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
	}
}
