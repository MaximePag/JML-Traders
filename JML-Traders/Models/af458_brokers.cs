//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JML_Traders.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class af458_brokers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public af458_brokers()
        {
            this.af458_appointments = new HashSet<af458_appointments>();
            this.af458_customers = new HashSet<af458_customers>();
        }
    
        public int id { get; set; }

        [Display(Name = "Nom du courtier :")]
        public string lastname { get; set; }

        [Display(Name = "Prénom :")]
        public string firstname { get; set; }

        [Display(Name = "Adresse mail :")]
        public string mail { get; set; }

        [Display(Name = "Numéro de téléphone :")]
        public string phoneNumber { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<af458_appointments> af458_appointments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<af458_customers> af458_customers { get; set; }
    }
}
