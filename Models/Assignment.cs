using System.ComponentModel.DataAnnotations;

namespace COMP_1640.Models
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public byte[] Image { get; set; }
        public string UrlImage { get; set; }
        //File Requiremnt
    }
}
