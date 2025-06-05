using DosyaTakipSistemi.Context;
using DosyaTakipSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DosyaTakipSistemi.Controllers
{
    public class DosyaController : Controller
    {
        MyContext _context;

        public DosyaController(MyContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var dosyalar = await _context.Dosyalar
                .Include(d => d.Taraflar)
                .ToListAsync();

            return View(dosyalar);
        }

        [HttpGet]   
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DosyaModel dosya)
        {
            if (ModelState.IsValid)
            {
                _context.Dosyalar.Add(dosya);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dosya);
        }

        public async Task<IActionResult> Details(int id)
        {
            var dosya = await _context.Dosyalar
                .Include(d => d.Taraflar)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (dosya == null)
            {
                return NotFound();
            }

            return View(dosya);
        }
    }
}
