using Music_Events.Models.EventsViewModels;
using Music_Events.Data;
using Microsoft.EntityFrameworkCore;
using Music_Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Music_Events.Pages
{
    public class AboutModel : PageModel
    {
        private readonly EventsContext _context;

        public AboutModel(EventsContext context)
        {
            _context = context;
        }
        public IList<EventDateGroup> EventGroup { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<EventDateGroup> data =
                    from ev in _context.Events
                    join b in _context.Bookings on ev.ID equals b.EventID
                    join a in _context.Artists on b.ArtistID equals a.ID
                    select new { 
                    ev,
                    b,
                    a
                    } into t1
                    group t1 by t1.ev.EventDate into g
                    select new EventDateGroup
                       {
                           EventDate = g.FirstOrDefault().ev.EventDate,
                           EventName = g.FirstOrDefault().ev.EventName,
                           ArtistCount = g.Count(m => m.b.ArtistID > 0),
                           TotalExpenses = g.Sum(m=>m.b.Payment)
                       };
            /*IQueryable<EventDateGroup> data = _context.Events.FromSqlRaw("
                    select e.EventDate, e.EventName, count(b.ArtistID), sum(b.Payment)
                    from Event e
                        join Booking b on b.EventID = e.ID
                        join Artist a on a.ID = b.ArtistID
                    group by e.EventDate, e.EventName
                    order by e.EventDate desc,
                    e.EventName asc
                ").ToList;*/


            EventGroup = await data.AsNoTracking().ToListAsync();
        }
    }
}
