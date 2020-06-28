namespace Ziekenhuis_StayHealthy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Afdeling")]
    public partial class Afdeling
    {
        [Key]
        public int Afdeling_ID { get; set; }

        [StringLength(50)]
        [DisplayName("Naam afdeling")]
        public string Naam { get; set; }
        [DisplayName("Maximale aantal patiënten")]
        public string Max_Patiënt { get; set; }
    }
}
