namespace DepoYonetim.Models;

public class Urun
{
    public int Id { get; set; }
    public string Ad { get; set; } = null!;
    public string? Barkod { get; set; }
    public string Birim { get; set; } = "adet";
}