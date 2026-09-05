namespace DepoYonetim.Models;

public class Depo
{
    public int Id { get; set; }
    public string Ad { get; set; } = null!;
    public int FabrikaId { get; set; }
    public Fabrika Fabrika { get; set; } = null!;
    public ICollection<Raf> Raflar { get; set; } = new List<Raf>();
}