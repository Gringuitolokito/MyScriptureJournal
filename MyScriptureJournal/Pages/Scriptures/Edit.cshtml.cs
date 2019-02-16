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
    public class EditModel : PageModel
    {
        private readonly MyScriptureJournal.Models.Context _context;

        public EditModel(MyScriptureJournal.Models.Context context)
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

            Scriptures = await _context.Scripture.FirstOrDefaultAsync(m => m.ID == id);

            if (Scriptures == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Scriptures).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScripturesExists(Scriptures.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ScripturesExists(int id)
        {
            return _context.Scripture.Any(e => e.ID == id);
        }
    }
}
