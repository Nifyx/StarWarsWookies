using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public class ModeleDataLayer : BaseDataLayer<Modele>
    {
        #region Public methods
        public List<Modele> Select(string libelle = "", int id = 0)
        {
            List<Modele> listeModeles = new List<Modele>();
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                if (libelle != "")
                {
                    listeModeles = context.Modele.Where(m => m.Libelle == libelle).ToList();
                }
                else if (id != 0)
                {
                    listeModeles = context.Modele.Where(m => m.ID == id).ToList();
                }
                else
                {
                    listeModeles = context.Modele.ToList();
                }
            }
            return listeModeles;
        }

        public void UpdateOrInsertOne(Modele modele)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                if (modele.ID == 0)
                {
                    context.Modele.Add(modele);
                }
                else
                {
                    context.Modele.Attach(modele);
                    context.Entry(modele).Property(m => m.Libelle).IsModified = true;
                }
                context.SaveChanges();
            }
        }

        public void delete(Modele modele)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                context.Modele.Attach(modele);
                context.Modele.Remove(modele);
                context.SaveChanges();
            }
        }

        #endregion Public methods

        #region Private methods

        protected override void BindListWithReader(SqlDataReader reader, List<Modele> list)
        {
            list.Add(new Modele() { ID = (int)reader["ID"], Libelle = reader["Libelle"].ToString() });
        }

        protected override string PrepareUpdateOrInsert(Modele t)
        {
            string requete = "INSERT INTO Modele (Libelle)"
                        + "VALUES ('" + t.Libelle + "')";
            if (t.ID != 0)
            {
                requete = " UPDATE Modele "
                        + " SET Libelle = '" + t.Libelle
                        + " WHERE ID = " + t.ID;
            }
            return requete;
        }
        #endregion Private methods
    }
}
