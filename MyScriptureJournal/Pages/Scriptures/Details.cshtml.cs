﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.ScripturesScaff
{
    public class DetailsModel : PageModel
    {
        private readonly MyScriptureJournal.Models.Context _context;

        public DetailsModel(MyScriptureJournal.Models.Context context)
        {
            _context = context;
        }

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
    }
}
