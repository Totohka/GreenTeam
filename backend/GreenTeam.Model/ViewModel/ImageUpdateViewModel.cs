using Microsoft.AspNetCore.Http;

namespace GreenTeam.Model.ViewModel
{
    public class ImageUpdateViewModel
    {
        public required IFormFile Image { get; set; }
        public int Product_id { get; set; }
        public int Photo_id { get; set;}
    }
}
