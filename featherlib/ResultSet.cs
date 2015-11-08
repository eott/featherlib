using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    class ResultSet
    {
        public MySqlDataReader reader { get; set; }
        public List<List<string>> rows { get; set; }
        protected int listIndex;

        public ResultSet(MySqlDataReader reader)
        {
            this.reader = reader;
        }

        public ResultSet(List<List<string>> rows)
        {
            this.rows = rows;
            this.listIndex = -1;
        }

        public bool read()
        {
            if (this.reader != null)
            {
                return this.reader.Read();
            }
            else if (this.rows != null)
            {
                if (this.listIndex < this.rows.Count - 1)
                {
                    this.listIndex++;
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

        public int getInt32(int index)
        {
            if (this.reader != null)
            {
                return this.reader.GetInt32(index);
            } else if (this.rows != null)
            {
                return int.Parse(this.rows[this.listIndex][index]);
            } else
            {
                throw new EmptyResultSetException("Tried to access field of an empty ResultSet instance with no underlying data structure.");
            }
        }

        public string getString(int index)
        {
            if (this.reader != null)
            {
                return this.reader.GetString(index);
            }
            else if (this.rows != null)
            {
                return this.rows[this.listIndex][index];
            }
            else
            {
                throw new EmptyResultSetException("Tried to access field of an empty ResultSet instance with no underlying data structure.");
            }
        }

        public DateTime getDateTime(int index)
        {
            if (this.reader != null)
            {
                return this.reader.GetDateTime(index);
            }
            else if (this.rows != null)
            {
                return DateTime.Parse(this.rows[this.listIndex][index]);
            }
            else
            {
                throw new EmptyResultSetException("Tried to access field of an empty ResultSet instance with no underlying data structure.");
            }
        }
    }
}
