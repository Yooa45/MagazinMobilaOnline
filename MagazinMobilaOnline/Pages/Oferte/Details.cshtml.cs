using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MagazinMobilaOnline.Data;
using MagazinMobilaOnline.Models;

namespace MagazinMobilaOnline.Pages.Oferte
{
    public class DetailsModel : PageModel
    {
        private readonly MagazinMobilaOnline.Data.MagazinMobilaOnlineContext _context;

        public DetailsModel(MagazinMobilaOnline.Data.MagazinMobilaOnlineContext context)
        {
            _context = context;
        }

      public Oferta Oferta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Oferta == null)
            {
                return NotFound();
            }

            var oferta = await _context.Oferta
                 .Include(p => p.Produs)
                 .FirstOrDefaultAsync(m => m.ID == id);
            if (oferta == null)
            {
                return NotFound();
            }
            else 
            {
                Oferta = oferta;
            }
            return Page();
        }
    }
}
