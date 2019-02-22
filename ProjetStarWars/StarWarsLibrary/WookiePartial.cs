using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    [MetadataType(typeof(WookieMetadata))]
    public partial class Wookie
    {
        #region Public methods

        public override string ToString()
        {
            return "Id : " + this.ID + ", Nom : " + this.Nom + ", Sexe : " + this.Sexe + ", Date de naissance : " + this.DateN + ", Points de vies : " + this.PointsDeVie;
        }
    
        #endregion
    }

    public class WookieMetadata
    {
        [Range(50, 100)]
        public Nullable<int> PointsDeVie { get; set; }
    }
}
