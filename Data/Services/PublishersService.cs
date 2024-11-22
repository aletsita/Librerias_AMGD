using Librerias_AMGD.Data.Models;
using Librerias_AMGD.Data.ViewModels;
using Librerias_AMGD.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Librerias_AMGD.Exceptions;
using System.Security.Policy;
using System.Text.RegularExpressions;
using PublisherModel = Librerias_AMGD.Data.Models.Publisher;

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
        public PublisherModel AddPublisher(PublisherVM publisher)
        {
            if (publisher == null)
                throw new ArgumentNullException(nameof(publisher), "El parámetro publisher no puede ser nulo.");

            if (StringStartsWithNumber(publisher.Name))
                throw new PublisherNameExceptions("El nombre empieza con un número", publisher.Name);

            var _publisher = new PublisherModel
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(_publisher);
            _context.SaveChanges();

            return _publisher;
        }


        public PublisherModel GetPublisherByID(int id) => _context.Publishers.FirstOrDefault(n => n.Id == id);

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
            else
            {
                throw new Exception($"La editorial con el Id {id} no existe!");
            }
        }

        private bool StringStartsWithNumber(string name) 
        {
            if (Regex.IsMatch(name, @"^\d")) return true;
            return false;
        }

    }
}
