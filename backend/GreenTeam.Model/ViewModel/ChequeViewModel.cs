using GreenTeam.Model.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Model.ViewModel
{
    public class ChequeCreateViewModel
    {
        public required IFormFile File { get; set; }
        public int User_id { get; set; }
    }
}
