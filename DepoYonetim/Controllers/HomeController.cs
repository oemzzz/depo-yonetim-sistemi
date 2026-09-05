using DepoYonetim.Data;
using DepoYonetim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepoYonetim.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _db;

    public HomeController(AppDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        // "Şu an hangi rafta hangi üründen kaç tane var"
        // RafStok'tan başlayıp Raf → Depo → Fabrika ve Urun tablolarını join'liyoruz
        var stoklar = _db.RafStoklari
            .Include(s => s.Raf)
                .ThenInclude(r => r.Depo)
                    .ThenInclude(d => d.Fabrika)
            .Include(s => s.Urun)
            .Where(s => s.Miktar > 0)          // stoğu biten satırları gizle
            .OrderBy(s => s.Raf.Kod)
            .ToList();

        return View(stoklar);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}