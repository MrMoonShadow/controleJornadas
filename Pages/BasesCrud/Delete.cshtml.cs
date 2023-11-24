﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using controleJornadas.Data;
using controleJornadas.Models;

namespace controleJornadas.Pages.BasesCrud
{
    public class DeleteModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public DeleteModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bases Bases { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bases = await _context.Bases.FirstOrDefaultAsync(m => m.Idbase == id);

            if (bases == null)
            {
                return NotFound();
            }
            else
            {
                Bases = bases;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bases = await _context.Bases.FindAsync(id);
            if (bases != null)
            {
                Bases = bases;
                _context.Bases.Remove(Bases);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
