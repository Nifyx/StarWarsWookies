using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    public partial class Planete
    {
        #region Public methods
        public override string ToString()
        {
            return "Id : " + this.ID + ", Nom : " + this.Nom;
        }
        #endregion Public methods
    }
}
