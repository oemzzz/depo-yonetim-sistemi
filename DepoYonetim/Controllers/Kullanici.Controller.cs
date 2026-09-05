using DepoYonetim.Data;
using DepoYonetim.Models;
using Microsoft.AspNetCore.Mvc;

namespace DepoYonetim.Controllers;

public class KullaniciController : Controller
{
    private readonly AppDbContext _db;

    public KullaniciController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View(_db.Kullanicilar.ToList());
    }

    public IActionResult Ekle()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Ekle(Kullanici kullanici)
    {
        _db.Kullanicilar.Add(kullanici);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Sil(int id)
    {
        var k = _db.Kullanicilar.Find(id);
        if (k != null)
        {
            _db.Kullanicilar.Remove(k);
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}