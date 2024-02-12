using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTeam.Model.Entities
{
    public class ChequeProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ChequeId { get; set; }
        public Cheque? Cheque {  get; set; } 
        public int ProductAmount { get; set; }
    }
}
