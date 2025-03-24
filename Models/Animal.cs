using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooNick.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty; // Initialized to avoid null warnings

        [Required]
        public string Species { get; set; } = string.Empty; // Initialized to avoid null warnings

        [Range(0, 100, ErrorMessage = "Age must be between 0 and 100.")]
        public int Age { get; set; }

        [Required]
        [ForeignKey("Enclosure")]
        public int EnclosureId { get; set; }
        public Enclosure? Enclosure { get; set; } // Nullable navigation property

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; } // Nullable navigation property

        [Required]
        public SizeEnum Size { get; set; } // Enum for size

        [Required]
        public DietaryClassEnum DietaryClass { get; set; } // Enum for dietary class

        [Required]
        public ActivityPatternEnum ActivityPattern { get; set; } // Enum for activity pattern

        [Required]
        public string Prey { get; set; } = string.Empty; // Initialized to avoid null warnings

        [Range(0, 100, ErrorMessage = "Space requirement must be between 0 and 100.")]
        public double SpaceRequirement { get; set; } = 0; // Initialized to avoid null warnings

        [Required]
        public SecurityLevelEnum SecurityRequirement { get; set; } // Enum for security requirement
    }
}
