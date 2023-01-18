using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MagazinMobilaOnline.Data;
using MagazinMobilaOnline.Models;

namespace MagazinMobilaOnline.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly MagazinMobilaOnline.Data.MagazinMobilaOnlineContext _context;

        public IndexModel(MagazinMobilaOnline.Data.MagazinMobilaOnlineContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Produs != null)
            {
                Produs = await _context.Produs.ToListAsync();
            }
        }
    }
}
