namespace DepoYonetim.Models;

public enum HareketTipi
{
    Giris = 1,
    Cikis = 2
}

public class StokHareketi
{
    public int Id { get; set; }
    public int RafId { get; set; }
    public Raf Raf { get; set; } = null!;
    public int UrunId { get; set; }
    public Urun Urun { get; set; } = null!;
    public int KullaniciId { get; set; }
    public Kullanici Kullanici { get; set; } = null!;
    public HareketTipi Tip { get; set; }
    public int Miktar { get; set; }
    public DateTime Tarih { get; set; }
}