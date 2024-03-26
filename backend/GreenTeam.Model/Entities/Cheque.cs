
namespace GreenTeam.Model.Entities
{
    public class Cheque
    {
        public int Id { get; set; }
        public string Path { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string DeliveryAddress { get; set; } = string.Empty;
        public bool IsPay { get; set; } = false;
        public bool IsPrint { get; set; } = false;
        public DateTime Date { get; set; }
        public User? User { get; set; }
        public List<ChequeProduct>? ChequeProducts { get; set; }
    }
}
