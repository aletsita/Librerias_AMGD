using Librerias_AMGD.Data.Models;
using Librerias_AMGD.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Policy;

namespace Librerias_AMGD.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        //Método que nos permite agregar un Publisher en la BD
        public void AddPublisher(PublisherVM Publisher)
        {
            var _publisher = new Librerias_AMGD.Data.Models.Publisher()
            {
                Name = Publisher.Name
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksAndAutorsVM GetPublisherData(int publisherId) 
        {
            var _publisherData = _context.Publishers.Where(n => n.Id == publisherId)
                .Select(n => new PublisherWithBooksAndAutorsVM()
                {
                    Name = n.Name,
                    BookAuthors = n.Books.Select(n => new BookAutorVM()
                    {
                        BooksName = n.Title,
                        BookAuthors = n.Book_Author.Select(n => n.Author.FullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }

        internal void DeletePublisherById(int id)
        {
            var _publisher = _context.Publishers.FirstOrDefault(n => n.Id == id);
            if (_publisher != null)
            {
                _context.Publishers.Remove(_publisher);
                _context.SaveChanges();
            }
        }

    }
}
