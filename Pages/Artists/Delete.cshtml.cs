﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly Music_Events.Data.EventsContext _context;

        public DeleteModel(Music_Events.Data.EventsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Artist Artist { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Artist = await _context.Artists
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Artist == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again.";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists.FindAsync(id);
            if(artist==null)
            {

                return NotFound();
            }
            try
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /*ex*/)
            {
                
                return RedirectToAction("./Delete", new { id, saveChangesError = true });

            }

           

            
        }
    }
}
