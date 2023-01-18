using System.ComponentModel.DataAnnotations;

namespace MagazinMobilaOnline.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage =
"Numele trebuie sa inceapa cu majuscula (ex. Ana sau Ana Maria)" )]
        public string ClientNume { get; set; }

        public string ClientAdresa { get; set; }

        public int ClientNrTelefon { get; set; }
    }
}
