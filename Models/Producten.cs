using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DistributiecenterFonq.Models
{
    public class Producten
    {
        [Required(ErrorMessage = "**Je moet een merk invullen")]
        public string Merk { get; set; }
        public string Type { get; set; }
        public string Afmeting { get; set; }
        public int Voorraad { get; set; }
        public int Gewicht { get; set; }
        public int Id { get; set; }
        public string Afbeelding { get; set; }


    }
}