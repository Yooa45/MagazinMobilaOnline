using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MagazinMobilaOnline.Data;
using MagazinMobilaOnline.Models;

namespace MagazinMobilaOnline.Pages.Comenzi
{
    public class CreateModel : ComandaProdusPageModel
    {
        private readonly MagazinMobilaOnline.Data.MagazinMobilaOnlineContext _context;

        public CreateModel(MagazinMobilaOnline.Data.MagazinMobilaOnlineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientID");
            var order = new Comanda();
            order.ComandaProduse = new List<ComandaProdus>();

            PopulateProducts(_context, order);
            return Page();
        }

        [BindProperty]
        public Comanda Comanda { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedProducts)
        {
            var order = new Comanda();
            order.ComandaProduse = new List<ComandaProdus>();
            if (selectedProducts != null)
            {
                order.ComandaProduse = new List<ComandaProdus>();
                foreach (var prod in selectedProducts)
                {
                    order.ComandaProduse.Add(new ComandaProdus
                    {
                        ProdusID = int.Parse(prod)
                    });
                }
            }

            var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
            .SelectMany(E => E.Errors)
            .Select(E => E.ErrorMessage)
            .ToList();

            if (await TryUpdateModelAsync(
                    order,
                    "Comanda",
                    i => i.DataComanda,
                    i => i.ClientID
                    ))
            {
                _context.Comanda.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["CustomerID"] = new SelectList(_context.Client, "ClientID", "ClientNume");
            PopulateProducts(_context, order);
            return Page();
        }
    }
}
