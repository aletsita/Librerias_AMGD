using System;
using System.Collections.Generic;

namespace Librerias_AMGD.Data.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Descripcion { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genero { get; set; }
        public string CoverUrl { get; set; }
        public int PublisherID { get; set; }
        public List<int> AutorIDs { get; set; }
    }
}
