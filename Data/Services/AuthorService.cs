using Librerias_AMGD.Data.Models;
using Librerias_AMGD.Data.ViewModels;
using System;

namespace Librerias_AMGD.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        //Método que nos permite agregar un Autor en la BD
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName,
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
    }
}
