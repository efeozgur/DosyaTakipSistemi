using DosyaTakipSistemi.Context;
using DosyaTakipSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using static DosyaTakipSistemi.Models.TarafModel;

namespace DosyaTakipSistemi.Controllers
{
    public class TarafController : Controller
    {
        MyContext _context;

        public TarafController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create(int dosyaId)
        {
            var taraf = new TarafModel
            {
                DosyaId = dosyaId
            };
            ViewBag.KararTuru = _context.Dosyalar
     .Where(d => d.Id == dosyaId)
     .Select(d => d.kararTur)
     .FirstOrDefault();

            return View(taraf);
        }

        // POST: Taraf/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TarafModel taraf)
        {
            if (ModelState.IsValid)
            {
                _context.Taraflar.Add(taraf);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Dosya", new { id = taraf.DosyaId });
            }

            // Hata varsa buraya düşer
            ViewBag.Hata = "ModelState geçersiz.";
            return View(taraf);
        }

        public async Task<IActionResult> TestTarafEkle()
        {
            var taraf = new TarafModel
            {
                AdSoyad = "Test Davalı",
                TarafTur = TarafTuru.Davali,
                DosyaId = 1 // Varsa bir dosya ID'si
            };

            _context.Taraflar.Add(taraf);
            await _context.SaveChangesAsync();

            return Content("Eklendi.");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var taraf = _context.Taraflar.FirstOrDefault(t => t.Id == id);
            if (taraf == null)
                return NotFound();

            return View(taraf);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TarafModel taraf)
        {
            if (ModelState.IsValid)
            {
                _context.Taraflar.Update(taraf);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Dosya", new { id = taraf.DosyaId });
            }

            return View(taraf);
        }




    }
}
