using System.ComponentModel.DataAnnotations;

namespace ZooNick.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int EnclosureId { get; set; }
        public Enclosure Enclosure { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
