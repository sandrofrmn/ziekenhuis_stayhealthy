using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ziekenhuis_StayHealthy.Models
{
    public class User
    {
        [Required]
        public string name { get; set; }
    }
}