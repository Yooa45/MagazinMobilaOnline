using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagazinMobilaOnline.Models
{
    public class Produs
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]

        public string Nume { get; set; }
        [Range(1, 8000)]
        public int Pret { get; set; }
        [Range(1, 20)]
        public int Stoc { get; set; }

        public ICollection<ComandaProdus>? ComandaProduse { get; set; }
    }
}
