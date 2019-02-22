using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkV2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BDD_STARWARSEntities context = new BDD_STARWARSEntities())
            {
                Droide newDroide = new Droide() { Matricule = "NewRobot", ModeleID = 1, DateF = DateTime.Now};
                context.Droide.Add(newDroide);
                context.SaveChanges();
            }
        }
    }
}
