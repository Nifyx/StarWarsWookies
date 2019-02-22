using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public class WookieDataLayer : BaseDataLayer<Wookie>
    {
        #region Public methods
        public List<Wookie> Select(string nom = "", int id = 0)
        {
            List<Wookie> listeWookies = new List<Wookie>();
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                if (nom != "")
                {
                    listeWookies = context.Wookie
                        .Include("Combat")
                        .Where(w => w.Nom == nom)
                        .ToList();
                }
                else if (id != 0)
                {
                    listeWookies = context.Wookie
                        .Include("Combat")
                        .Where(w => w.ID == id)
                        .ToList();
                }
                else
                {
                    listeWookies = context.Wookie
                        .Include("Combat")
                        .ToList();
                }
            }
            return listeWookies;
        }

        public void UpdateOrInsertOne(Wookie wookie)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                if(wookie.ID == 0)
                {
                    context.Wookie.Add(wookie);
                }
                else
                {
                    context.Wookie.Attach(wookie);
                    context.Entry(wookie).Property(w => w.Nom).IsModified = true;
                    context.Entry(wookie).Property(w => w.PlaneteID).IsModified = true;
                }
                context.SaveChanges();
            }
        }

        public void delete(Wookie wookie)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                context.Wookie.Attach(wookie);
                context.Wookie.Remove(wookie);
                context.SaveChanges();
            }
        }
        #endregion Public methods
        #region Private methods
        protected override void BindListWithReader(SqlDataReader reader, List<Wookie> list)
        {
            list.Add(new Wookie() { ID = (int)reader["WookieID"], Nom = reader["WookieNom"].ToString(), Sexe = (bool)reader["Sexe"], DateN = (DateTime)reader["DateN"], Planete = new Planete() { ID = (int)reader["PlaneteID"], Nom = reader["PlaneteNom"].ToString() }, PlaneteID = (int)reader["PlaneteID"] });
        }

        protected override string PrepareUpdateOrInsert(Wookie t)
        {
            string requete = "INSERT INTO Wookie (Nom, DateN, Sexe, PlaneteID)"
                        + " VALUES ('" + t.Nom + "', '" + t.DateN + "', " + Convert.ToInt32(t.Sexe) + ", " + t.PlaneteID + ")";
            if (t.ID != 0)
            {
                requete = " UPDATE Wookie "
                        + " SET Nom = '" + t.Nom + "', Sexe = " + Convert.ToInt32(t.Sexe) + ", PlaneteID = " + t.PlaneteID
                        + " WHERE ID = " + t.ID;
                Console.WriteLine(requete);
            }
            return requete;
        }
        #endregion Private methods
    }
}
