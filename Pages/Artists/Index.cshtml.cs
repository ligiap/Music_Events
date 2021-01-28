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
    public class IndexModel : PageModel
    {
        private readonly Music_Events.Data.EventsContext _context;

        public IndexModel(Music_Events.Data.EventsContext context)
        {
            _context = context;
        }

        public IList<Artist> Artist { get;set; }

        public async Task OnGetAsync()
        {
            Artist = await _context.Artists
                .Include(s => s.Tracks)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
