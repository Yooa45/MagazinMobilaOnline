using System.ComponentModel.DataAnnotations;

namespace MagazinMobilaOnline.Models
{
    public class Comanda
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataComanda { get; set; }

        public int ClientID { get; set; }

        public Client? Client { get; set; }

        public ICollection<ComandaProdus>? ComandaProduse { get; set; }
    }
}
