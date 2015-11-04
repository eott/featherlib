using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class LibraryItem
    {
        public int libraryItemId { get; set; }

        public Library library { get; set; }

        public string name { get; set; }

        public LibraryItem(int id, Library library, string name)
        {
            this.libraryItemId = id;
            this.library = library;
            this.name = name;
        }
    }
}
