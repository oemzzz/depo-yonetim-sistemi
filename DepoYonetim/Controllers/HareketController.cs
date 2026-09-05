using DepoYonetim.Data;
using DepoYonetim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DepoYonetim.Controllers;

public class HareketController : Controller
{
    private readonly AppDbContext _db;

    public HareketController(AppDbContext db)
    {
        _db = db;
    }

    // Hareket geçmişini listele
    public IActionResult Index()
    {
        var hareketler = _db.StokHareketleri
            .Include(h => h.Kullanici)
            .Include(h => h.Raf)
            .Include(h => h.Urun)
            .OrderByDescending(h => h.Tarih)
            .ToList();
        return View(hareketler);
    }

    // Hareket formunu göster
    public IActionResult Ekle()
    {
        ViewBag.Kullanicilar = _db.Kullanicilar.ToList();
        ViewBag.Raflar = _db.Raflar.ToList();
        ViewBag.Urunler = _db.Urunler.ToList();
        return View();
    }

    // Hareketi kaydet + stoğu güncelle
    [HttpPost]
    public IActionResult Ekle(int rafId, int urunId, int kullaniciId, HareketTipi tip, int miktar)
    {
        // 1) Bu raf+ürün için mevcut stok satırını bul
        var stok = _db.RafStoklari
            .FirstOrDefault(s => s.RafId == rafId && s.UrunId == urunId);

        // 2) Yoksa yeni bir satır başlat
        if (stok == null)
        {
            stok = new RafStok { RafId = rafId, UrunId = urunId, Miktar = 0 };
            _db.RafStoklari.Add(stok);
        }

        // 3) Giriş ise ekle, çıkış ise düş
        if (tip == HareketTipi.Giris)
        {
            stok.Miktar += miktar;
        }
        else
        {
            if (stok.Miktar < miktar)
            {
                TempData["Hata"] = "Rafta yeterli ürün yok!";
                return RedirectToAction("Ekle");
            }
            stok.Miktar -= miktar;
        }

        // 4) Hareketi geçmişe kaydet
        _db.StokHareketleri.Add(new StokHareketi
        {
            RafId = rafId,
            UrunId = urunId,
            KullaniciId = kullaniciId,
            Tip = tip,
            Miktar = miktar,
            Tarih = DateTime.Now
        });

        // 5) İkisini tek seferde kaydet
        _db.SaveChanges();

        return RedirectToAction("Index");
    }
}