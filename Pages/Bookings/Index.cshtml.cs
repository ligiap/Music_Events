using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Music_Events.Data;
using Music_Events.Models;

namespace Music_Events.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly Music_Events.Data.EventsContext _context;

        public IndexModel(Music_Events.Data.EventsContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public IList<Booking> Bookings { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<Booking> bookingsIQ = from s in _context.Bookings
                                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                bookingsIQ = bookingsIQ.Where(s => s.Event.EventName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    bookingsIQ = bookingsIQ.OrderByDescending(s => s.Event.EventName);
                    break;
                case "Date":
                    bookingsIQ = bookingsIQ.OrderBy(s => s.Event.EventDate);
                    break;
                case "date_desc":
                    bookingsIQ = bookingsIQ.OrderByDescending(s => s.Event.EventDate);
                    break;
                default:
                    bookingsIQ = bookingsIQ.OrderBy(s => s.Event.EventName);
                    break;
            }



            Bookings = await bookingsIQ
                .Include(b => b.Artist)
                .Include(b => b.Event)
                .ToListAsync();



        }
    }
}
