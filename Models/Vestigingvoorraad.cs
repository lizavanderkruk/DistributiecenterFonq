using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistributiecenterFonq.Models
{
    public class Vestigingvoorraad
    {
        public string Naam { get; set; }
        public int VestigingId { get; set; }

        [Range(0, 2000)]
        public int Voorraad { get; set; }
        public int ProductId { get; set; }
    }
}