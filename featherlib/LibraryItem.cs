using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    class LibraryItem
    {
        protected int libraryItemId;

        protected Library library;

        protected string name;

        public LibraryItem(int id, Library library, string name)
        {
            this.libraryItemId = id;
            this.library = library;
            this.name = name;
        }
    }
}
