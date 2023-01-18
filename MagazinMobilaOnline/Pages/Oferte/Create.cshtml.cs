using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MagazinMobilaOnline.Data;
using MagazinMobilaOnline.Models;

namespace MagazinMobilaOnline.Pages.Oferte
{
    public class CreateModel : PageModel
    {
        private readonly MagazinMobilaOnline.Data.MagazinMobilaOnlineContext _context;

        public CreateModel(MagazinMobilaOnline.Data.MagazinMobilaOnlineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Produs"] = new SelectList(_context.Produs, "ID", "Nume");
            return Page();
        }

        [BindProperty]
        public Oferta Oferta { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var offer = new Oferta();
            if (await TryUpdateModelAsync<Oferta>(
                offer,
                "Oferta",
                i => i.DataExpirare,
                i => i.ProdusID,
                i => i.Nume,
                i => i.Reducere
                ))
            {
                _context.Oferta.Add(Oferta);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["Product"] = new SelectList(_context.Produs, "ID", "Name");

            return Page();
        }
    }
}
