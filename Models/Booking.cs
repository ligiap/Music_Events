using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Events.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public int ArtistID { get; set; }
        public int EventID { get; set; }



        [Display(Name = "Performer's Fee")]
        [Column(TypeName = "decimal(8,2)")]
        [Range(0, 999999.99)]
        public decimal Payment { get; set; }
        public Artist Artist { get; set; }
        public Event Event { get; set; }


    }
}
