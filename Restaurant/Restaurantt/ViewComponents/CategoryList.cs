using Microsoft.AspNetCore.Mvc;
using Restaurantt.Data;
using System.Linq;

namespace Restaurantt.ViewComponents
{
	public class CategoryList:ViewComponent
	{
		private readonly ApplicationDbContext _db;
		public CategoryList(ApplicationDbContext db)
		{
			_db = db;

		}
		public IViewComponentResult Invoke()
		{
			var category = _db.Kategoris.ToList();
			return View(category);
		}
	}
}
