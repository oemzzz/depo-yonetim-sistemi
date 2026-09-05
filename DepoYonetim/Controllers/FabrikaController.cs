using DepoYonetim.Data;
using DepoYonetim.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepoYonetim.Controllers;

public class FabrikaController : Controller
{
    private readonly AppDbContext _db;

    public FabrikaController(AppDbContext db)
    {
        _db = db;
    }

    // Listeleme sayfası
    public IActionResult Index()
    {
        var fabrikalar = _db.Fabrikalar.ToList();
        return View(fabrikalar);
    }

    // Ekleme formunu göster
    public IActionResult Ekle()
    {
        return View();
    }

    // Formdan gelen veriyi kaydet
    [HttpPost]
    public IActionResult Ekle(Fabrika fabrika)
    {
        _db.Fabrikalar.Add(fabrika);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    // Silme
    public IActionResult Sil(int id)
    {
        var fabrika = _db.Fabrikalar.Find(id);
        if (fabrika != null)
        {
            _db.Fabrikalar.Remove(fabrika);
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}