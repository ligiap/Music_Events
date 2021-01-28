using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Music_Events.Data;
using Music_Events.Models;

namespace Music_Events.Pages.Artists
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
            return Page();
        }

        [BindProperty]
        public Artist Artist { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyArtist = new Artist();

            if (await TryUpdateModelAsync<Artist>(
                emptyArtist,
                "artist", //Prefix for form value.
                s => s.StageName))


            {
                _context.Artists.Add(Artist);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            return Page();
           }
    }
}
