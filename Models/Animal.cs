using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooNick.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Species { get; set; }

        [Range(0, 100, ErrorMessage = "Age must be between 0 and 100.")]
        public int Age { get; set; }

        [Required]
        [ForeignKey("Enclosure")]
        public int EnclosureId { get; set; }
        public Enclosure? Enclosure { get; set; } // Nullable om EF-fouten te vermijden

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; } // Nullable om EF-fouten te vermijden
    }
}
