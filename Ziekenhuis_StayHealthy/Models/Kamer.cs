namespace Ziekenhuis_StayHealthy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kamer")]
    public partial class Kamer
    {
        [Key]
        public int Kamer_ID { get; set; }

        [Required]
        [StringLength(30)]
        public string Kamernaam { get; set; }

        public int Afdeling_ID { get; set; }
    }
}
