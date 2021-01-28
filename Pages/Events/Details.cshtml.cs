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
    public class DetailsModel : PageModel
    {
        private readonly Music_Events.Data.EventsContext _context;

        public DetailsModel(Music_Events.Data.EventsContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events
                .Include(s => s.Bookings)
                .ThenInclude(e => e.Artist)
                .ThenInclude(i=>i.Tracks)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
