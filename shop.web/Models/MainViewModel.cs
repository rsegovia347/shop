

namespace shop.web.Models
{
    using shop.web.Data;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class ProductViewModel : Product
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }
    }


}
