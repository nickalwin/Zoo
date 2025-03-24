using System.ComponentModel.DataAnnotations;
using System.Collections.Generic; // Added for List<Animal>

namespace ZooNick.Models
{
    public class Enclosure
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Initialized to avoid null warnings
        public string Description { get; set; } = string.Empty; // Initialized to avoid null warnings
        public int Capacity { get; set; }

        public List<Animal> Animals { get; set; } = []; // Initialized to avoid null warnings
        public ClimateEnum Climate { get; set; } // Enum for climate
        public HabitatTypeEnum HabitatType { get; set; } // Flags enum for habitat types
        public SecurityLevelEnum SecurityLevel { get; set; } // Enum for security level
        public double Size { get; set; } // Double for size
    }
}
