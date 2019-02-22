using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkV2
{
    public partial class Droide
    {
        public override string ToString()
        {
            return "Id : " + this.ID + ", Matricule : " + this.Matricule + ", Date de fabrication : " + this.DateF;
        }
    }
}
