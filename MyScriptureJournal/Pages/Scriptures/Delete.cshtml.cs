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
    public class DeleteModel : PageModel
    {
        private readonly MyScriptureJournal.Models.Context _context;

        public DeleteModel(MyScriptureJournal.Models.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Scripture Scriptures { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Scriptures = await _context.Scriptures.FirstOrDefaultAsync(m => m.ID == id);

            if (Scriptures == null)
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

            Scriptures = await _context.Scriptures.FindAsync(id);

            if (Scriptures != null)
            {
                _context.Scriptures.Remove(Scriptures);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
