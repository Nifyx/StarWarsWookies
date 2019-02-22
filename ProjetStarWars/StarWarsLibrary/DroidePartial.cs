using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsLibrary
{
    [MetadataType(typeof(DroideMetadata))]
    public partial class Droide
    {
        #region Public methods

        public override string ToString()
        {
            return "Id : " + this.ID + ", Matricule : " + this.Matricule + ", DateDeFabrication : " + this.DateF + ", Modele : " + this.Modele + ", Points de vies : " + this.PointsDeVie;
        }
        #endregion Public methods
    }

    public class DroideMetadata
    {
        [Required]
        public string Matricule { get; set; }
        [Range(0,60)]
        public Nullable<int> PointsDeVie { get; set; }
    }
}
