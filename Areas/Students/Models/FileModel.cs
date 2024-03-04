﻿namespace COMP_1640.Areas.Students.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public byte[]? Data { get; set; }
        public long Length { get; set; }
        public string? ContentType { get; set; }
    }
}
