namespace MagazinMobilaOnline.Models
{
    public class Produs
    {
        public int ID { get; set; }

        public string Nume { get; set; }

        public int Pret { get; set; }

        public int Stoc { get; set; }

        public ICollection<ComandaProdus>? ComandaProduse { get; set; }
    }
}
