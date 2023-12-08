using System;
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
    public class DetailsModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public DetailsModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Base Bases { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bases = await _context.Bases.FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
