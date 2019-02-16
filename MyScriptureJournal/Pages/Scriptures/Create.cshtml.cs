using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.ScripturesScaff
{
    public class CreateModel : PageModel
    {
        private readonly MyScriptureJournal.Models.Context _context;

        public CreateModel(MyScriptureJournal.Models.Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Scripture Scriptures { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Scriptures.Add(Scriptures);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}