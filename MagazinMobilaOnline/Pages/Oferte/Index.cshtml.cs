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
    public class IndexModel : PageModel
    {
        private readonly MagazinMobilaOnline.Data.MagazinMobilaOnlineContext _context;

        public IndexModel(MagazinMobilaOnline.Data.MagazinMobilaOnlineContext context)
        {
            _context = context;
        }

        public IList<Oferta> Oferta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Oferta != null)
            {
                Oferta = await _context.Oferta
                .Include(o => o.Produs).ToListAsync();
            }
        }
    }
}
