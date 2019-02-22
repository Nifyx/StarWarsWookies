using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public class CombatDataLayer
    {
        #region Public methods
        public List<Combat> Select(int id = 0, int wookieID = 0, int droideID = 0, int attaqueID = 0)
        {
            List<Combat> listeCombats = new List<Combat>();
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                listeCombats = context.Combat
                        .Include("Wookie")
                        .Include("Droide.Modele")
                        .ToList();

                if (id != 0 )
                {
                    listeCombats = context.Combat
                        .Include("Wookie")
                        .Include("Droide.Modele")
                        .Where(c => c.ID == id)
                        .ToList();
                }

                if (wookieID != 0)
                {
                    listeCombats = context.Combat
                        .Include("Wookie")
                        .Include("Droide.Modele")
                        .Where(c => c.WookieID == wookieID)
                        .ToList();
                    if (attaqueID != 0)
                    {
                        listeCombats = context.Combat
                        .Include("Wookie")
                        .Include("Droide.Modele")
                        .Where(c => c.WookieID == wookieID && c.AttaqueID == attaqueID)
                        .ToList();
                    }
                }

                if (droideID != 0)
                {
                    listeCombats = context.Combat
                        .Include("Wookie")
                        .Include("Droide.Modele")
                        .Where(c => c.DroideID == droideID)
                        .ToList();
                    if(attaqueID != 0)
                    {
                        listeCombats = context.Combat
                        .Include("Wookie")
                        .Include("Droide.Modele")
                        .Where(c => c.DroideID == droideID && c.AttaqueID == attaqueID)
                        .ToList();
                    }
                }

                if (attaqueID != 0)
                {
                    listeCombats = context.Combat
                        .Include("Wookie")
                        .Include("Droide.Modele")
                        .Where(c => c.AttaqueID == attaqueID)
                        .ToList();
                }
            }
            return listeCombats;
        }

        public void UpdateOrInsertOne(Combat combat)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                context.Combat.Add(combat);
                if (combat.ID != 0)
                {
                    context.Combat.Attach(combat);
                    context.Entry(combat).Property(c => c.PointsDeVieDroide).IsModified = true;
                    context.Entry(combat).Property(c => c.PointsDeVieWookie).IsModified = true;
                    context.Entry(combat).Property(c => c.Vainqueur).IsModified = true;
                }
                context.SaveChanges();
            }
        }

        public void delete(Combat combat)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                context.Combat.Attach(combat);
                context.Combat.Remove(combat);
                context.SaveChanges();
            }
        }
        #endregion Public methods
    }
}
