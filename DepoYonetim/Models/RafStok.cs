namespace DepoYonetim.Models;

public class RafStok
{
    public int RafId { get; set; }
    public Raf Raf { get; set; } = null!;
    public int UrunId { get; set; }
    public Urun Urun { get; set; } = null!;
    public int Miktar { get; set; }
}