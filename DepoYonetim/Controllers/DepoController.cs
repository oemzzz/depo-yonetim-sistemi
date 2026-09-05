using DepoYonetim.Data;
using DepoYonetim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepoYonetim.Controllers;

public class DepoController : Controller
{
    private readonly AppDbContext _db;

    public DepoController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        // Depoları listelerken ait oldukları fabrikayı da getir (Include = join)
        var depolar = _db.Depolar
            .Include(d => d.Fabrika)
            .ToList();
        return View(depolar);
    }

    public IActionResult Ekle()
    {
        // Formdaki dropdown'u doldurmak için fabrika listesini gönder
        ViewBag.Fabrikalar = _db.Fabrikalar.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Ekle(Depo depo)
    {
        _db.Depolar.Add(depo);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Sil(int id)
    {
        var depo = _db.Depolar.Find(id);
        if (depo != null)
        {
            _db.Depolar.Remove(depo);
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}