//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zeiterfassung
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mitarbeiter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mitarbeiter()
        {
            this.Zeiten = new HashSet<Zeiten>();
        }
    
        public int id_Mitarbeiter { get; set; }
        public string Nachname { get; set; }
        public string Vorname { get; set; }
        public Nullable<int> Resturlaub { get; set; }
        public Nullable<double> Regelarbeitszeit { get; set; }
        public Nullable<int> id_Abteilung { get; set; }
        public Nullable<int> id_Praeferenz { get; set; }
        public Nullable<int> id_Rolle { get; set; }
    
        public virtual Abteilung Abteilung { get; set; }
        public virtual Praeferenzen Praeferenzen { get; set; }
        public virtual Rollen Rollen { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zeiten> Zeiten { get; set; }
    }
}