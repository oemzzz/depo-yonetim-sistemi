namespace DepoYonetim.Models;

public class Fabrika
{
    public int Id { get; set; }
    public string Ad { get; set; } = null!;
    public ICollection<Depo> Depolar { get; set; } = new List<Depo>();
}