using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NToastNotify;
using Restaurantt.Data;
using Restaurantt.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurantt.Areas.Musteri.Controllers
{

    [Area("Musteri")] //attribute
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;//dependency injection

        private readonly ApplicationDbContext _db;
        private readonly IToastNotification _toast;
        private readonly IWebHostEnvironment _whe;

       public HomeController(ILogger<HomeController> logger,ApplicationDbContext db, IToastNotification toast, IWebHostEnvironment whe)
        {
            _logger = logger;
            _db = db;
            _toast = toast;
            _whe = whe;
        }

        public IActionResult Index()
        {
            var menu = _db.Menus.Where(i => i.OzelMenu).ToList();
            return View(menu);
        }
        public IActionResult CategoryDetails(int? id)
        {
            var menu = _db.Menus.Where
                (i => i.KategoriID==id).ToList();
            ViewBag.KategoriID = id;
            return View(menu);
        }
        public IActionResult Menu()
        {
            var menu = _db.Menus.ToList();


            return View(menu);
        }
        public IActionResult Rezervasyon()
        {
            return View();
        }

        // POST: Yonetici/Rezervasyon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rezervasyon([Bind("ID,Name,Email,TelefonNo,Sayi,Saat,Tarih")] Rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                _db.Add(rezervasyon);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Rezervasyon işleminiz başarıyla gerçekleşti.Teşekkür Ederiz...");
                return RedirectToAction(nameof(Index));
            }
            return View(rezervasyon);
        }

        public IActionResult Galeri()

        {
            var galeri = _db.Galeris.ToList();
            return View(galeri);
        }
        public IActionResult Hakkında()
        {
            var hakkında=_db.Hakkımızdas.ToList();
            return View(hakkında);
        }
        public IActionResult Blog()
        {
            return View();
        }

        // POST: Yonetici/Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Blog(Blog blog)
        {

            if (ModelState.IsValid)
            {
                blog.Tarih = DateTime.Now;
                
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    var fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(_whe.WebRootPath, @"WebSite\menu");
                    var ext = Path.GetExtension(files[0].FileName);
                    if (blog.Image != null)
                    {
                        var imagePath = Path.Combine(_whe.WebRootPath, blog.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }
                    using (var filesStreams = new FileStream(Path.Combine(uploads, fileName + ext), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    blog.Image = @"\WebSite\menu\" + fileName + ext;
                }

                _db.Add(blog);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Yorumunuz İletildi:))Teşekkür Ederiz");
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Yonetici/İletisim/Create
        public IActionResult İletisim()
        {
            return View();
        }

        // POST: Yonetici/İletisim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> İletisim([Bind("ID,Name,EMail,Telefon,Mesaj")] İletisim İletisim)
        {
            if (ModelState.IsValid)

            {
               İletisim.Tarih=DateTime.Now;
                _db.Add(İletisim);
                await _db.SaveChangesAsync();
                _toast.AddSuccessToastMessage("Mesajınız başarıyla iletilmiştir");
                return RedirectToAction(nameof(Index));
            }
            return View(İletisim);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
