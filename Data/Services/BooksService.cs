using System;
using System.Collections.Generic;
using System.Linq;
using Librerias_AMGD.Data.Models;
using Librerias_AMGD.Data.ViewModels;

namespace Librerias_AMGD.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }
        //Método que nos permite agregar un libro en la BD
        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Descripcion = book.Descripcion,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genero = book.Genero,
                Autor = book.Autor,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        //Método que nos permite obtener una lista de todos los libros en la BD
        public List<Book> GetAllBks() => _context.Books.ToList();
        //Método que nos permite obtener el libro que estamos pidiendo de la BD
        public Book GetBookById(int bookid) => _context.Books.FirstOrDefault(n => n.id == bookid);

        //Método que nos permite modificar un libro que se encuentra en la BD
        public Book UpdateBookById(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Descripcion = book.Descripcion;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.DateRead;
                _book.Rate = book.Rate;
                _book.Genero = book.Genero;
                _book.Autor = book.Autor;
                _book.CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeleteBookById(int bookid)
        {
            var _book = _context.Books.FirstOrDefault(n => n.id == bookid);

            if (_book != null)
            {
                _context.Books.Remove(_book);
                _context.SaveChanges();
            }
        }
    }
}
