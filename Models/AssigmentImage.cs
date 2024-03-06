using Org.BouncyCastle.Crypto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMP_1640.Models
{
    public class AssigmentImage
    {
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }

        public int AssignmentId { get; set; }
        [ForeignKey("AssignmentId")]
        public Assignment Assignment { get; set; }
    }
}
