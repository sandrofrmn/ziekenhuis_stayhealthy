namespace Ziekenhuis_StayHealthy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Eten")]
    public partial class Eten
    {
        [Key]
        public int Eten_ID { get; set; }

        [StringLength(50)]
        public string NaamEten { get; set; }

        [Column(TypeName = "image")]
        public byte[] ImageEten { get; set; }

        public int? Gang { get; set; }
    }
}
