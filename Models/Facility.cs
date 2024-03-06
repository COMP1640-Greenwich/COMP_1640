using System.ComponentModel.DataAnnotations;

namespace COMP_1640.Models
{
    public class Facility
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Coordinator_Name { get; set; }

    }
}
