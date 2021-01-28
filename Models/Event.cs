using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Events.Models
{
    public enum Type { 
    Rock,
    Pop,
    Disco,
    Alternative,
    Electronic,
    CeapaBunaDeBeut,
    ArdeiIute,
    VarzaMuzicala
    }
    public class Event
    {
    public int ID { get; set; }
    [Display(Name = "Event Name")]
    public string EventName { get; set; }
    [Display(Name = "Event Date")]

    [DataType(DataType.Date)]
    //[DisplayFormat(DataFormatString = @"{mm/dd/yyyy}")]
        public DateTime EventDate{ get; set; }

    public string FullEvent {
            get {
                return string.Format("{0} {1}", EventName, EventDate.ToString("yyyy-MM-dd"));
            }
        }
    
    [DisplayFormat(NullDisplayText = "No type")]
    [Display(Name = "Event Type")]
    public Type? Type { get; set; }

    public ICollection<Booking> Bookings { get; set; }

    }
}
