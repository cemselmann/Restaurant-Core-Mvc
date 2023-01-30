using Microsoft.AspNetCore.Mvc;
using Restaurantt.Data;
using System.Linq;

namespace Restaurantt.ViewComponents
{
	public class Comment:ViewComponent
	{
		private readonly ApplicationDbContext _db;
		public Comment(ApplicationDbContext db)
		{
			_db = db;
		}
		public IViewComponentResult Invoke()
		{
			var comment=_db.Blogs.Where(i=>i.Onay).ToList();
			return View(comment);
		}
	}
}
