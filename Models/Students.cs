using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP_1640.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? Age { get; set; }
        [ValidateNever] 
        public int? FacilityId {  get; set; }
        [ForeignKey("FacilityId")]
        [ValidateNever]
        public Facility? Facility { get; set; }
    }
}
