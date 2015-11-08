using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class EmptyResultSetException : Exception
    {
        public EmptyResultSetException(string msg) : base(msg) { }
    }

    public class NoServerConnectionException : Exception
    {
        public NoServerConnectionException(string msg) : base(msg) { }
    }
}
