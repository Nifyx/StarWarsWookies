using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public class AttaqueDataLayer
    {
        #region Public methods
        public List<Attaque> Select(int id = 0)
        {
            List<Attaque> listeAttaques = new List<Attaque>();
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                if (id != 0)
                {
                    listeAttaques = context.Attaque
                        .Include("Planete")
                        .Where(a => a.ID == id)
                        .ToList();
                }
                else
                {
                    listeAttaques = context.Attaque
                        .Include("Planete")
                        .ToList();
                }
            }
            return listeAttaques;
        }

        public void UpdateOrInsertOne(Attaque attaque)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                context.Attaque.Add(attaque);
                if (attaque.ID != 0)
                {
                    context.Attaque.Attach(attaque);
                    context.Entry(attaque).Property(a => a.NbDroides).IsModified = true;
                    context.Entry(attaque).Property(a => a.NbWookies).IsModified = true;
                    context.Entry(attaque).Property(a => a.Victorieux).IsModified = true;
                    context.Entry(attaque).Property(a => a.DateFin).IsModified = true;
                    context.Entry(attaque).Property(a => a.PlaneteID).IsModified = true;
                }
                context.SaveChanges();
            }
        }

        public void delete(Attaque attaque)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                context.Attaque.Attach(attaque);
                context.Attaque.Remove(attaque);
                context.SaveChanges();
            }
        }
        #endregion Public methods
    }
}
