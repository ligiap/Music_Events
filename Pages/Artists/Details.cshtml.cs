using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Music_Events.Data;
using Music_Events.Models;

namespace Music_Events.Pages.Artists
{
    public class DetailsModel : PageModel
    {
        private readonly Music_Events.Data.EventsContext _context;

        public DetailsModel(Music_Events.Data.EventsContext context)
        {
            _context = context;
        }

        public Artist Artist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await _context.Artists
                .Include(s=>s.Bookings)
                .ThenInclude(e=>e.Event)
                .Include(s=>s.Tracks)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Artist == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
