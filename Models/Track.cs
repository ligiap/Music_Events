using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Events.Models
{
    public class Track
    {
        public int ID { get; set; }
        public int ArtistID { get; set; }
        [Display(Name = "Track Name")]
        public string TrackName { get; set; }

        //[Range(typeof(TimeSpan), "00:00:00", "00:59:59")]
        [DisplayFormat(DataFormatString = @"{0:mm\:ss}")]
        
        public TimeSpan Length { get; set; }
        public Artist Artist { get; set; }
    
    }
}
