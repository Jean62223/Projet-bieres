//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_biere.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_biere
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Id_type { get; set; }
        public int Id_Alcool { get; set; }
    
        public virtual T_Alcool T_Alcool { get; set; }
        public virtual T_type T_type { get; set; }
    }
}
