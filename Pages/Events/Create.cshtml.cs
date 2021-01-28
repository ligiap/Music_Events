using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Music_Events.Data;
using Music_Events.Models;

namespace Music_Events.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly Music_Events.Data.EventsContext _context;

        public CreateModel(Music_Events.Data.EventsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["enumList"] = Enum.GetNames(typeof(Music_Events.Models.Type));
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            var emptyEvent = new Event();

            if (await TryUpdateModelAsync<Event>(
                emptyEvent,
                "event", //Prefix for form value.
                s => s.EventName, s => s.EventDate, s => s.Type))


            {
                _context.Events.Add(Event);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            return Page();
        }
    
    }
}
