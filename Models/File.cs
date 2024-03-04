namespace COMP_1640.Models
{
    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public long Length { get; set; }
        public string ContentType { get; set; }
    }
}
