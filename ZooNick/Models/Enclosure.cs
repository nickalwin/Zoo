using System.ComponentModel.DataAnnotations;

namespace ZooNick.Models
{
    public class Enclosure
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
    }
}
