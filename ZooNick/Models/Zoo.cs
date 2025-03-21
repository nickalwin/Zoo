using System.Collections.Generic;

namespace ZooNick.Models
{
    public class Zoo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Enclosure> Enclosures { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Category> Categories { get; set; }
    }
}
