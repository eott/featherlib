using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    /// <summary>
    /// Used by the DbConnectionStatus to signal the currect status.
    /// </summary>
    public enum DbConnectionStatus
    {
        CONNECTED,
        UNAUTHORIZED,
        UNINITIALIZED,
        UNCONNECTED
    }

    /// <summary>
    /// Used to identify what kind of object to be fetched from the server and/or
    /// database. This avoids having to check against unknown ObjectIdentifiers
    /// or checking for class names (as they might be part of an inheritance
    /// hierarchy).
    /// </summary>
    public enum ObjectIdentifier
    {
        Library,
        LibraryItem,
        User
    }
}
