using Microsoft.AspNetCore.Http;

namespace GreenTeam.Model.ViewModel
{
    public class FileCreateViewModel
    {
        public required IFormFile File { get; set; }
        public int User_id { get; set; }
        public int Cheque_id { get; set;}
    }
}
