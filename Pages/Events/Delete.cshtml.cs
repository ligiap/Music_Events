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
    public class DeleteModel : PageModel
    {
        private readonly Music_Events.Data.EventsContext _context;

        public DeleteModel(Music_Events.Data.EventsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Event == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventd = await _context.Events.FindAsync(id);

            if (eventd == null)
            {
                return NotFound();
            }

            try
            {
                _context.Events.Remove(eventd);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            catch (DbUpdateException /* ex */)
            {
                
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }



        }
    }
}
