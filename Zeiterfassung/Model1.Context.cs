﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class WorkTimeContext : DbContext
    {
        public WorkTimeContext()
            : base("name=WorkTimeContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Abteilung> Abteilung { get; set; }
        public virtual DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public virtual DbSet<Praeferenzen> Praeferenzen { get; set; }
        public virtual DbSet<Rechte> Rechte { get; set; }
        public virtual DbSet<Rollen> Rollen { get; set; }
        public virtual DbSet<tmp> tmp { get; set; }
        public virtual DbSet<Zeiten> Zeiten { get; set; }
    
        public virtual int GetTimes(Nullable<int> personID)
        {
            var personIDParameter = personID.HasValue ?
                new ObjectParameter("PersonID", personID) :
                new ObjectParameter("PersonID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetTimes", personIDParameter);
        }
    
        public virtual int DelTMP()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DelTMP");
        }
    
        public virtual ObjectResult<Nullable<int>> GetUrlaub(Nullable<int> personID)
        {
            var personIDParameter = personID.HasValue ?
                new ObjectParameter("PersonID", personID) :
                new ObjectParameter("PersonID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetUrlaub", personIDParameter);
        }
    }
}
