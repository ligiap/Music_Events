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
    public class DeleteModel : PageModel
    {
        private readonly Music_Events.Data.EventsContext _context;

        public DeleteModel(Music_Events.Data.EventsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            /*ViewData["ArtistID"] = (_context.Set<Artist>(), "ID", "StageName");
            ViewData["EventID"] = (_context.Set<Event>(), "ID", "EventName");*/
            if (id == null)
            {
                return NotFound();
            }

            Booking = await _context.Bookings
                .Include(b => b.Artist)
                .Include(b => b.Event).FirstOrDefaultAsync(m => m.ID == id);

            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Booking = await _context.Bookings.FindAsync(id);

            if (Booking != null)
            {
                _context.Bookings.Remove(Booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
