using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IList<Scripture> Scriptures { get;set; }

        public async Task OnGetAsync()
        {
            Scriptures = await _context.Scripture.ToListAsync();
        }
    }
}
