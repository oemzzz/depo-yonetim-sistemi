namespace DepoYonetim.Models;

public class Raf
{
    public int Id { get; set; }
    public string Kod { get; set; } = null!;
    public int DepoId { get; set; }
    public Depo Depo { get; set; } = null!;
    public ICollection<RafStok> Stoklar { get; set; } = new List<RafStok>();
}