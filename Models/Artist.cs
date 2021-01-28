using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Events.Models
{
    public class Artist
    {
        public int ID { get; set; }
        [Display(Name="Artist")]
        public string StageName { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
