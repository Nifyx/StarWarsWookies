using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public abstract class BaseDataLayer<T> where T : new()
    {
        #region Public methods
        public virtual List<T> SelectAll(string requete)
        {
            List<T> listeT = new List<T>();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Properties.Settings.Default.connectionString;
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = requete;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.BindListWithReader(reader, listeT);
                        }
                    }
                }
            }
            return listeT;
        }
        public virtual void UpdateOrInsertOneT(T t)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = Properties.Settings.Default.connectionString;
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = this.PrepareUpdateOrInsert(t);
                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion Public methods

        #region Internal methods
        protected abstract void BindListWithReader(SqlDataReader reader, List<T> list);
        protected abstract string PrepareUpdateOrInsert(T t);
        #endregion Internal methods
    }
}
