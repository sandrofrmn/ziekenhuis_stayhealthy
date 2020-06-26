namespace Ziekenhuis_StayHealthy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Medicatie")]
    public partial class Medicatie
    {
        [Key]
        public int Medicatie_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Naam { get; set; }

        [Required]
        [StringLength(50)]
        public string Merk { get; set; }

        [Required]
        [StringLength(10)]
        public string Dosis { get; set; }

        public int? Patient_ID { get; set; }
    }
}
