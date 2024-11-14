using System.Collections.Generic;

namespace Librerias_AMGD.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        //Propiedades de navegacion
        public List<Book_Author> Book_Author { get; set; }
    }
}
