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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dosya = _context.Dosyalar.FirstOrDefault(d => d.Id == id);
            if (dosya == null)
                return NotFound();

            return View(dosya);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DosyaModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var mevcutDosya = _context.Dosyalar.FirstOrDefault(d => d.Id == model.Id);
            if (mevcutDosya == null)
                return NotFound();

            // Bilgileri güncelle
            mevcutDosya.EsasNo = model.EsasNo;
            mevcutDosya.KararNo = model.KararNo;
            mevcutDosya.Mahkeme = model.Mahkeme;
            mevcutDosya.KararTebligTarihi = model.KararTebligTarihi;
            mevcutDosya.HarcDurumu = model.HarcDurumu;
            mevcutDosya.kararTur = model.kararTur;

            _context.SaveChanges();

            return RedirectToAction("Details", new { id = model.Id });
        }

    }
}
