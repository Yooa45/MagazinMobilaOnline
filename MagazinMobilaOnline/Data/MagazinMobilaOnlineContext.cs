using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MagazinMobilaOnline.Models;

namespace MagazinMobilaOnline.Data
{
    public class MagazinMobilaOnlineContext : DbContext
    {
        public MagazinMobilaOnlineContext (DbContextOptions<MagazinMobilaOnlineContext> options)
            : base(options)
        {
        }

        public DbSet<MagazinMobilaOnline.Models.Client> Client { get; set; } = default!;

        public DbSet<MagazinMobilaOnline.Models.Produs> Produs { get; set; }

        public DbSet<MagazinMobilaOnline.Models.Comanda> Comanda { get; set; }
        public DbSet<MagazinMobilaOnline.Models.Oferta> Oferta { get; set; }
    }
}
