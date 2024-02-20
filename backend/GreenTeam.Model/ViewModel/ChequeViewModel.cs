using GreenTeam.Model.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Model.ViewModel
{
    public class FileCreateViewModel
    {
        public required IFormFile File { get; set; }
        public int User_id { get; set; }
        public int Cheque_id { get; set;}
    }
}
