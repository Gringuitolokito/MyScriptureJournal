using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.ScripturesScaff
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.Context _context;

        public IndexModel(MyScriptureJournal.Models.Context context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; }

        [BindProperty(SupportsGet = true)]
        //SearchString: contains the text users enter in the search text box.
        public string SearchString { get; set; }

        public IList<Scripture> Scriptures { get;set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        //public SelectList Dates { get; set; }
        
        //[BindProperty(SupportsGet = true)]
        //public DateTime MarkDate { get; set; }

        public async Task OnGetAsync()
        {
            //IQueryable<DateTime> genreQuery = from m in _context.Scripture
              //                              orderby m.Date
              //                              select m.Date;
            Scriptures = await _context.Scripture.ToListAsync();
            var scriptures = from m in _context.Scripture
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(SearchString));
            }
            //if (!string.IsNullOrEmpty(MarkDate.ToString()))
            //{
            //    scriptures = scriptures.Where(x => x.Date == MarkDate);
            //}
            //Dates = new SelectList(await genreQuery.Distinct().ToListAsync());
            Scriptures = await scriptures.ToListAsync();
        }
    }
}
