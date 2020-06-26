namespace Ziekenhuis_StayHealthy.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PatientEDM : DbContext
    {
        public PatientEDM()
            : base("name=PatientEDM")
        {
        }

        public virtual DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .Property(e => e.Voornaam)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Achternaam)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.Telefoonnummer)
                .IsUnicode(false);
        }
    }
}
