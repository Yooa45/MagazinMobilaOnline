using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MagazinMobilaOnline.Data;
using MagazinMobilaOnline.Models;

namespace MagazinMobilaOnline.Pages.Comenzi
{
    public class IndexModel : PageModel
    {
        private readonly MagazinMobilaOnline.Data.MagazinMobilaOnlineContext _context;

        public IndexModel(MagazinMobilaOnline.Data.MagazinMobilaOnlineContext context)
        {
            _context = context;
        }

        public IList<Comanda> Comanda { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Comanda != null)
            {
                this.Comanda = await _context.Comanda
                    .Include(c => c.Client)
                    .Include(p => p.ComandaProduse).ThenInclude(p => p.Produs)
                    .ToListAsync();
            }
        }
    }
}
