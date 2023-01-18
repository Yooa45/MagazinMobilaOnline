using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagazinMobilaOnline.Data;
using MagazinMobilaOnline.Models;

namespace MagazinMobilaOnline.Pages.Comenzi
{
    public class EditModel : ComandaProdusPageModel
    {
        private readonly MagazinMobilaOnline.Data.MagazinMobilaOnlineContext _context;

        public EditModel(MagazinMobilaOnline.Data.MagazinMobilaOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Comanda Comanda { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Comanda == null)
            {
                return NotFound();
            }

            var comanda = await _context.Comanda
                .Include(c => c.Client)
                .Include(c => c.ComandaProduse).ThenInclude(c => c.Produs)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (comanda == null)
            {
                return NotFound();
            }
            Comanda = comanda;

            ViewData["CustomerID"] = new SelectList(_context.Client, "ClientID", "ClientNume");
            PopulateProducts(_context, comanda);

            return Page();
        }
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedProducts)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderToUpdate = await _context.Comanda
                .Include(c => c.Client)
                .Include(c => c.ComandaProduse).ThenInclude(c => c.Produs)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (orderToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Comanda>(
                orderToUpdate,
                "Order",
                i => i.DataComanda,
                i => i.ClientID))
            {
                UpdateOrderProducts(_context, orderToUpdate, selectedProducts);
                _context.Comanda.Update(orderToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["CustomerID"] = new SelectList(_context.Client, "ClientID", "ClientNume");
            PopulateProducts(_context, orderToUpdate);
            return Page();
        }

        private bool ComandaExists(int id)
        {
          return _context.Comanda.Any(e => e.ID == id);
        }
    }
}
