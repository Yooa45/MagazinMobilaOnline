﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagazinMobilaOnline.Data;
using MagazinMobilaOnline.Models;

namespace MagazinMobilaOnline.Pages.Oferte
{
    public class EditModel : PageModel
    {
        private readonly MagazinMobilaOnline.Data.MagazinMobilaOnlineContext _context;

        public EditModel(MagazinMobilaOnline.Data.MagazinMobilaOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Oferta Oferta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Oferta == null)
            {
                return NotFound();
            }

            var oferta = await _context.Oferta
                 .Include(p => p.Produs)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);
            if (oferta == null)
            {
                return NotFound();
            }
            Oferta = oferta;
           ViewData["Produs"] = new SelectList(_context.Produs, "ID", "Nume");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var offerToUpdate = await _context.Oferta
                .Include(p => p.Produs)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (offerToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Oferta>(
                offerToUpdate,
                "Oferta",
                i => i.DataExpirare,
                i => i.Reducere,
                i => i.Nume,
                i => i.ProdusID
                ))
            {
                _context.Oferta.Update(offerToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            ViewData["Product"] = new SelectList(_context.Produs, "ID", "Name");
            return Page();
        }

        private bool OfertaExists(int id)
        {
          return _context.Oferta.Any(e => e.ID == id);
        }
    }
}
