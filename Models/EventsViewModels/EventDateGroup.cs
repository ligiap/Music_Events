using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music_Events.Models.EventsViewModels
{
    public class EventDateGroup
    {
        public string EventName { get; set; }
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        public int ArtistCount { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [Range(0, 999999.99)]
        public decimal TotalExpenses { get; set; }
    }
}
