using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Model.Entities
{
    public class Cheque
    {
        public int Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<ChequeProduct>? ChequeProducts { get; set; }
    }
}
