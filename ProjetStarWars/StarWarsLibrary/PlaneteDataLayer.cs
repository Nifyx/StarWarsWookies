using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public class PlaneteDataLayer : BaseDataLayer<Planete>
    {
        #region Public methods
        public List<Planete> Select(string nom = "", int id = 0)
        {
            List<Planete> listePlanetes = new List<Planete>();
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                if (nom != "")
                {
                    listePlanetes = context.Planete.Where(p => p.Nom == nom).ToList();
                }
                else if(id != 0)
                {
                    listePlanetes = context.Planete.Where(p => p.ID == id).ToList();
                }
                else
                {
                    listePlanetes = context.Planete.ToList();
                }
            }
            //string requete = "SELECT ID, Nom FROM Planete ORDER BY Nom";
            return listePlanetes;
        }

        public void UpdateOrInsertOne(Planete planete)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                if (planete.ID == 0)
                {
                    context.Planete.Add(planete);
                }
                else
                {
                    context.Planete.Attach(planete);
                    context.Entry(planete).Property(p => p.Nom).IsModified = true;
                }
                context.SaveChanges();
            }
        }

        public void delete(Planete planete)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                context.Planete.Attach(planete);
                context.Planete.Remove(planete);
                context.SaveChanges();
            }
        }
        #endregion Public methods

        #region Private methods
        protected override void BindListWithReader(SqlDataReader reader, List<Planete> list)
        {
            list.Add(new Planete() { ID = (int)reader["ID"], Nom = reader["Nom"].ToString() });
        }

        protected override string PrepareUpdateOrInsert(Planete t)
        {
            string requete = "INSERT INTO Planete (Nom)"
                        + "VALUES ('" + t.Nom + "')";
            if (t.ID != 0)
            {
                requete = " UPDATE Planete "
                        + " SET Nom = '" + t.Nom
                        + " WHERE ID = " + t.ID;
            }
            return requete;
        }
        #endregion Private methods        
    }
}
