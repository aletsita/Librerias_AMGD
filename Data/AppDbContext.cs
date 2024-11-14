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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Author)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Author)
                .HasForeignKey(bi => bi.AuthorId);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
        //Utilizaremos este metodo para obtener y enviar datos a la BD
    
}
