using Microsoft.AspNetCore.Mvc.RazorPages;
using MagazinMobilaOnline.Migrations;

namespace MagazinMobilaOnline.Models
{
    public class ComandaProdusPageModel:PageModel
    {
        public List<AssignedProdusData> availableProducts;
        public void PopulateProducts(MagazinMobilaOnline.Data.MagazinMobilaOnlineContext context, Comanda Comanda)
        {
            var allProducts = context.Produs;
            var orderProducts = new HashSet<int>(Comanda.ComandaProduse.Select(p => p.ProdusID));
            availableProducts = new List<AssignedProdusData>();
            foreach (var prod in allProducts)
            {
                availableProducts.Add(new AssignedProdusData
                {
                    ProdusID = prod.ID,
                    Nume = prod.Nume,
                    Assigned = orderProducts.Contains(prod.ID),
                    Pret = prod.Pret
                });
            }
        }

        public void UpdateOrderProducts(
            MagazinMobilaOnline.Data.MagazinMobilaOnlineContext context,
            Comanda Comanda,
            string[] selectedProducts
            )
        {
            if (selectedProducts == null)
            {
                Comanda.ComandaProduse = new List<ComandaProdus>();
                return;
            }

            var selectedProductsMap = new HashSet<string>(selectedProducts);
            var orderProducts = new HashSet<int>(Comanda.ComandaProduse.Select(p => p.ID));

            foreach (var prod in context.Produs)
            {
                if (selectedProductsMap.Contains(prod.ID.ToString()))
                {
                    if (!orderProducts.Contains(prod.ID))
                    {
                        Comanda.ComandaProduse.Add(new ComandaProdus
                        {
                           ComandaID = Comanda.ID,
                            ProdusID = prod.ID
                        });
                    }
                }
                else
                {
                    if (orderProducts.Contains(prod.ID))
                    {
                        ComandaProdus productToRemove = Comanda.ComandaProduse.SingleOrDefault(p => p.ProdusID == prod.ID);
                        if (productToRemove != null)
                        {
                            context.Remove<ComandaProdus>(productToRemove);
                        }
                    }
                }
            }
        }
    }
}

