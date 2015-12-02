using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    /// <summary>
    /// Is used when an operation on a result set is called, that has no
    /// underlying data structure.
    /// NOTE: This is not the same as calling an operation on a result set
    /// that has a data structure set, but contains no data. Think of
    /// iterating over null instead of over an empty collection.
    /// </summary>
    public class EmptyResultSetException : Exception
    {
        public EmptyResultSetException(string msg) : base(msg) { }
    }

    /// <summary>
    /// Is used when an operation on a server connection is called, that has
    /// no server set.
    /// </summary>
    public class NoServerConnectionException : Exception
    {
        public NoServerConnectionException(string msg) : base(msg) { }
    }
}
