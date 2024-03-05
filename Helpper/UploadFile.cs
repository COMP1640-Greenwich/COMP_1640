using System.ComponentModel.DataAnnotations;

namespace COMP_1640.Helpper
{
    public class UploadFile
    {
            [Required(ErrorMessage = "Please choose a file!")]
            [DataType(DataType.Upload)]
            [FileExtensions(Extensions = "zip, pdf, png, jpg, jpeg, gif")]
            [Display(Name = "Upload file support idea")]
            public IFormFile FileUpload { get; set; }
    }
}
