using DepoYonetim.Data;
using DepoYonetim.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepoYonetim.Controllers;

public class UrunController : Controller
{
    private readonly AppDbContext _db;

    public UrunController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var urunler = _db.Urunler.ToList();
        return View(urunler);
    }

    public IActionResult Ekle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Ekle(Urun urun)
    {
        _db.Urunler.Add(urun);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Sil(int id)
    {
        var urun = _db.Urunler.Find(id);
        if (urun != null)
        {
            _db.Urunler.Remove(urun);
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}