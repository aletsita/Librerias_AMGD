using Librerias_AMGD.Data.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Librerias_AMGD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
