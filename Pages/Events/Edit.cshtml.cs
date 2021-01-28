using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Music_Events.Data;
using Music_Events.Models;

namespace Music_Events.Pages.Events
{
    public class EditModel : PageModel
    {
        private readonly Music_Events.Data.EventsContext _context;

        public EditModel(Music_Events.Data.EventsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["enumList"] = Enum.GetNames(typeof(Music_Events.Models.Type));

            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events.FindAsync(id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var eventToUpdate = await _context.Events.FindAsync(id);
            if (eventToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Event>(
                eventToUpdate,
                "event",
                s => s.EventName, s => s.EventDate, s => s.Type))
            {
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
