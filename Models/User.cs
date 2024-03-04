using System.ComponentModel.DataAnnotations;

namespace COMP_1640.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Birthday { get; set; }
       
    }
}
