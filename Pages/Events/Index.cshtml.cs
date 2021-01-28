using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Music_Events.Data;
using Music_Events.Models;

namespace Music_Events.Pages.Events
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
        public IList<Event> Events { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<Event> eventsIQ = from s in _context.Events
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                eventsIQ = eventsIQ.Where(s => s.EventName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    eventsIQ = eventsIQ.OrderByDescending(s => s.EventName);
                    break;
                case "Date":
                    eventsIQ = eventsIQ.OrderBy(s => s.EventDate);
                    break;
                case "date_desc":
                    eventsIQ = eventsIQ.OrderByDescending(s => s.EventDate);
                    break;
                default:
                    eventsIQ = eventsIQ.OrderBy(s => s.EventName);
                    break;
            }

            Events = await eventsIQ.AsNoTracking().ToListAsync();
        }
    }
}
