using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    /// <summary>
    /// Wraps around the result of a request to the server. As the server might use
    /// different data storage/retrieval technologies and we don't want to incur
    /// the additional cost of converting everything to a common format, we instead
    /// create a common interface that works with different data storages.
    /// 
    /// For example, if the server uses a MySql database, the result set works on a
    /// MySqlDataReader. If the data came from a socket connection to a remote server,
    /// the data structure will be something like a table with string entries.
    /// 
    /// In both cases the interface for the client is the same, while the internal
    /// data retrieval is different.
    /// </summary>
    public class ResultSet
    {
        /// <summary>
        /// The MySqlDataReader containing the data.
        /// </summary>
        public MySqlDataReader Reader { get; set; }

        /// <summary>
        /// A table (as list of lists) containing the string-converted data.
        /// </summary>
        public List<List<string>> Rows { get; set; }

        /// <summary>
        /// If a table is used, points to the currently read row.
        /// </summary>
        protected int ListIndex;

        /// <summary>
        /// Constructor. Creates a ResultSet working with a MySqlDataReader.
        /// </summary>
        /// <param name="reader">The data reader containing the data.</param>
        public ResultSet(MySqlDataReader reader)
        {
            this.Reader = reader;
        }

        /// <summary>
        /// Constructor. Creates a ResultSet working with table.
        /// </summary>
        /// <param name="rows">The table, as list of lists with string
        /// entries.</param>
        public ResultSet(List<List<string>> rows)
        {
            this.Rows = rows;
            this.ListIndex = -1;
        }

        /// <summary>
        /// Consumes one row of the underlying data structure and returns if
        /// the new row exists or if we have reached the end.
        /// Calling functions are required to call this function to advance
        /// to the next row and must call it before trying to access a row,
        /// including the first (if any) row.
        /// </summary>
        /// <throws>EmptyResultSetException when the method was called on a
        /// ResultSet with no underlying data structure.</throws>
        /// <returns>True, if the advance to the next row was successful and the
        /// row is not empty.</returns>
        public bool Read()
        {
            if (this.Reader != null)
            {
                return this.Reader.Read();
            }
            else if (this.Rows != null)
            {
                if (this.ListIndex < this.Rows.Count - 1)
                {
                    this.ListIndex++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new EmptyResultSetException("Tried to read from an empty ResultSet instance with no underlying data structure.");
            }
        }

        /// <summary>
        /// Returns the value of the current row with the given index as 32bit int.
        /// 
        /// NOTE: The return type of this method is int, which is platform-dependant
        /// and might in fact not be a int32 value, but e.g. int64 instead. However
        /// since the underlying data structure of the ResultSet can currently not
        /// be expected to support 64 bit ints, you should assume it returns ints
        /// with a max value of those of 32 bit ints.
        /// </summary>
        /// <param name="index">The index of the field in the row.</param>
        /// <throws>EmptyResultSetException when the method was called on a
        /// ResultSet with no underlying data structure.</throws>
        /// <returns>The intval of the field with the given index in the current
        /// row.</returns>
        public int GetInt32(int index)
        {
            if (this.Reader != null)
            {
                return this.Reader.GetInt32(index);
            }
            else if (this.Rows != null)
            {
                return int.Parse(this.Rows[this.ListIndex][index]);
            }
            else
            {
                throw new EmptyResultSetException("Tried to access field of an empty ResultSet instance with no underlying data structure.");
            }
        }

        /// <summary>
        /// Returns the value of the current row with the given index as string.
        /// 
        /// </summary>
        /// <param name="index">The index of the field in the row.</param>
        /// <throws>EmptyResultSetException when the method was called on a
        /// ResultSet with no underlying data structure.</throws>
        /// <returns>The value of the field with the given index in the current
        /// row.</returns>
        public string GetString(int index)
        {
            if (this.Reader != null)
            {
                return this.Reader.GetString(index);
            }
            else if (this.Rows != null)
            {
                return this.Rows[this.ListIndex][index];
            }
            else
            {
                throw new EmptyResultSetException("Tried to access field of an empty ResultSet instance with no underlying data structure.");
            }
        }

        /// <summary>
        /// Returns the value of the current row with the given index parsed as
        /// a DateTime object. This method does not try to parse the value itself
        /// and instead uses the same date/time format as the DateTime class.
        /// 
        /// </summary>
        /// <param name="index">The index of the field in the row.</param>
        /// <throws>EmptyResultSetException when the method was called on a
        /// ResultSet with no underlying data structure.</throws>
        /// <returns>The value of the field with the given index in the current
        /// row parsed as DateTime object.</returns>
        public DateTime GetDateTime(int index)
        {
            if (this.Reader != null)
            {
                return this.Reader.GetDateTime(index);
            }
            else if (this.Rows != null)
            {
                return DateTime.Parse(this.Rows[this.ListIndex][index]);
            }
            else
            {
                throw new EmptyResultSetException("Tried to access field of an empty ResultSet instance with no underlying data structure.");
            }
        }
    }
}
