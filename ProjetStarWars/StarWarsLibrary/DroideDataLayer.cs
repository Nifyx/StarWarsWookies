using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public class DroideDataLayer : BaseDataLayer<Droide>
    {
        #region Public methods
        public List<Droide> Select(string libelle = "", int id = 0)
        {
            List<Droide> listeDroides = new List<Droide>();
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                if (libelle != "")
                {
                    listeDroides = context.Droide
                        .Include("Modele")
                        .Include("Combat")
                        .Where(m => m.Matricule == libelle)
                        .ToList();
                }
                else if (id != 0)
                {
                    listeDroides = context.Droide
                        .Include("Modele")
                        .Include("Combat")
                        .Where(m => m.ID == id)
                        .ToList();
                }
                else
                {
                    listeDroides = context.Droide
                        .Include("Modele")
                        .Include("Combat")
                        .ToList();
                }
            }
            return listeDroides;
        }

        public void UpdateOrInsertOne(Droide droide)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                context.Droide.Add(droide);
                if (droide.ID != 0)
                {
                    context.Droide.Attach(droide);
                    context.Entry(droide).Property(d => d.Matricule).IsModified = true;
                    context.Entry(droide).Property(d => d.ModeleID).IsModified = true;
                    context.Entry(droide).Property(d => d.PointsDeVie).IsModified = true;
                }
                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges

                    context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }

        public void delete(Droide droide)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                context.Droide.Attach(droide);
                context.Droide.Remove(droide);
                context.SaveChanges();
            }
        }
        #endregion Public methods

        #region Private methods
        protected override void BindListWithReader(SqlDataReader reader, List<Droide> list)
        {
            list.Add(new Droide() { ID = (int)reader["DroideID"], DateF = (DateTime)reader["DateF"], Matricule = reader["Matricule"].ToString(), Modele = new Modele() { ID = (int)reader["ModeleID"], Libelle = reader["Libelle"].ToString() }, ModeleID = (int)reader["ModeleID"] });
        }

        protected override string PrepareUpdateOrInsert(Droide t)
        {
            string requete = "INSERT INTO Droide (Matricule, DateF, ModeleID)"
                        + "VALUES ('" + t.Matricule + "', '" + t.DateF + "', " + t.ModeleID + ")";
            if (t.ID != 0)
            {
                requete = " UPDATE Droide "
                        + " SET Matricule = '" + t.Matricule + "', ModeleID = " + t.ModeleID
                        + " WHERE ID = " + t.ID;
            }
            return requete;
        }
        #endregion Private methods
    }
}
