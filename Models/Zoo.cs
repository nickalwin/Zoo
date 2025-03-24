using System.Collections.Generic;

namespace ZooNick.Models
{
public class Zoo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // Initialize to avoid null warnings
    public List<Enclosure> Enclosures { get; set; } = new List<Enclosure>(); // Initialize
    public List<Animal> Animals { get; set; } = new List<Animal>(); // Initialize
    public List<Category> Categories { get; set; } = new List<Category>(); // Initialize

    }
}
