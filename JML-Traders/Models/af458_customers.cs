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
    
    public partial class af458_customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public af458_customers()
        {
            this.af458_appointments = new HashSet<af458_appointments>();
        }
    
        public int id { get; set; }

        [Display(Name = "Nom du client :")]
        public string lastname { get; set; }
        
        public string firstname { get; set; }
        public string mail { get; set; }
        public string phoneNumber { get; set; }
        public int budget { get; set; }
        public int id_af458_brokers { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<af458_appointments> af458_appointments { get; set; }
        public virtual af458_brokers af458_brokers { get; set; }
    }
}
