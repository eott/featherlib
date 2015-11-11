using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace featherlib
{
    public class ResultSet
    {
        public MySqlDataReader Reader { get; set; }
        public List<List<string>> Rows { get; set; }
        protected int ListIndex;

        public ResultSet(MySqlDataReader reader)
        {
            this.Reader = reader;
        }

        public ResultSet(List<List<string>> rows)
        {
            this.Rows = rows;
            this.ListIndex = -1;
        }

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

        public int GetInt32(int index)
        {
            if (this.Reader != null)
            {
                return this.Reader.GetInt32(index);
            } else if (this.Rows != null)
            {
                return int.Parse(this.Rows[this.ListIndex][index]);
            } else
            {
                throw new EmptyResultSetException("Tried to access field of an empty ResultSet instance with no underlying data structure.");
            }
        }

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
