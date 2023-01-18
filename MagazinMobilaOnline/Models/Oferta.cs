using System.ComponentModel.DataAnnotations;

namespace MagazinMobilaOnline.Models
{
    public class Oferta
    {
        public int ID { get; set; }

        public String Nume { get; set; }
        [Range (1,99)]

        public int Reducere { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataExpirare { get; set; }

        public int ProdusID { get; set; }

        public Produs? Produs { get; set; }
    }
}
