using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP_1640.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Title must be less than 255 chracters!")]
        public string Title { get; set; }
        public List<AssigmentImage> Images { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Public")]
        public bool Status { get; set; }
        [ForeignKey("User")]
        [Display(Name = "User Id")]
        public string UserId { get; set; }
    }
}
