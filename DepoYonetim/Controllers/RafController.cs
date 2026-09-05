using DepoYonetim.Data;
using DepoYonetim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepoYonetim.Controllers;

public class RafController : Controller
{
    private readonly AppDbContext _db;

    public RafController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var raflar = _db.Raflar
            .Include(r => r.Depo)
            .ToList();
        return View(raflar);
    }

    public IActionResult Ekle()
    {
        ViewBag.Depolar = _db.Depolar.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Ekle(Raf raf)
    {
        _db.Raflar.Add(raf);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Sil(int id)
    {
        var raf = _db.Raflar.Find(id);
        if (raf != null)
        {
            _db.Raflar.Remove(raf);
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}