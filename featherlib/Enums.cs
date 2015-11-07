using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public enum DbConnectionStatus
    {
        CONNECTED,
        UNAUTHORIZED,
        UNINITIALIZED,
        UNCONNECTED
    }

    public enum ObjectIdentifier
    {
        Library,
        LibraryItem,
        User
    }
}
