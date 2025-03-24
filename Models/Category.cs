using System.ComponentModel.DataAnnotations;

namespace ZooNick.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Initialized to avoid null warnings
        public string Description { get; set; } = string.Empty; // Initialized to avoid null warnings
    }
}
