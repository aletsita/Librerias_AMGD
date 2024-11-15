using System.Collections.Generic;

namespace Librerias_AMGD.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }
    public class PublisherWithBooksAndAutorsVM
    {
        public string Name { get; set; }
        public List<BookAutorVM> BookAuthors { get; set; }
    }
    public class BookAutorVM
    {
        public string BooksName { get; set; }
        public List<string> BookAuthors { get; set; }
    }
}
