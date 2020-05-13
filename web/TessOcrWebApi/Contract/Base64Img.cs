using System.ComponentModel.DataAnnotations;

namespace TessOcrWebApi.Contract
{
    public class ImgData
    {
        [Required]
        public string Base64 { get; set; }
    }
}
