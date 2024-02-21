using Microsoft.AspNetCore.Http;

namespace GreenTeam.Model.ViewModel
{
    public class ImageCreateViewModel
    {
        public required IFormFile Image { get; set; }
        public int Product_id { get; set; }
    }
}
