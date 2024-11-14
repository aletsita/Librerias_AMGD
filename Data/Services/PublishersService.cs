using Librerias_AMGD.Data.Models;
using Librerias_AMGD.Data.ViewModels;
using System;
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
    }
}
