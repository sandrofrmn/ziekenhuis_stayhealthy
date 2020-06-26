namespace Ziekenhuis_StayHealthy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [Key]
        public int Patiënt_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Voornaam { get; set; }

        [Required]
        [StringLength(50)]
        public string Achternaam { get; set; }

        [Required]
        [StringLength(70)]
        public string Adres { get; set; }

        [Column(TypeName = "date")]
        public DateTime Geboortedatum { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefoonnummer { get; set; }

        public int? Afdeling_ID { get; set; }

        public int? Kamer_ID { get; set; }
    }
}
