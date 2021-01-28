using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Music_Events.Data;
using Music_Events.Models;

namespace Music_Events.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly Music_Events.Data.EventsContext _context;

        public CreateModel(Music_Events.Data.EventsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(bool? saveChangesError = false)
        {
            ViewData["ArtistID"] = new SelectList(_context.Set<Artist>(), "ID", "StageName");
            //ViewData["EventID"] = new SelectList(_context.Set<Event>(), "ID", "EventName");
            ViewData["EventID"] = new SelectList(_context.Set<Event>(), "ID", "FullEvent");

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Couldn't add booking. Possible duplicate entry. Try again!";
            }
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }
        public string ErrorMessage { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _context.Bookings.Add(Booking);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                return RedirectToAction("./Create", new { saveChangesError = true });
            }
        }
    }
}
