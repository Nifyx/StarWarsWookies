//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StarWarsLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Combat
    {
        public int ID { get; set; }
        public bool Vainqueur { get; set; }
        public System.DateTime DateCombat { get; set; }
        public Nullable<int> PointsDeVieWookie { get; set; }
        public Nullable<int> PointsDeVieDroide { get; set; }
        public Nullable<int> WookieID { get; set; }
        public Nullable<int> DroideID { get; set; }
        public Nullable<int> AttaqueID { get; set; }
    
        public virtual Attaque Attaque { get; set; }
        public virtual Droide Droide { get; set; }
        public virtual Wookie Wookie { get; set; }
    }
}
