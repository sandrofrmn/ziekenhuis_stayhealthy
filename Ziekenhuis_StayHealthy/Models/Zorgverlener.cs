namespace Ziekenhuis_StayHealthy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zorgverlener")]
    public partial class Zorgverlener
    {
        [Key]
        public int Zorgverlener_ID { get; set; }

        [StringLength(50)]
        public string Naam { get; set; }

        [StringLength(50)]
        public string Functie { get; set; }
    }
}
