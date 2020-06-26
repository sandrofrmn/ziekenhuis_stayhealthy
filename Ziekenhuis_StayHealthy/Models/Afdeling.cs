namespace Ziekenhuis_StayHealthy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Afdeling")]
    public partial class Afdeling
    {
        [Key]
        public int Afdeling_ID { get; set; }

        [StringLength(50)]
        public string Naam { get; set; }

        public int? Max_Patiënt { get; set; }
    }
}
