using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using controleJornadas.Data;
using controleJornadas.Models;

namespace controleJornadas.Pages.JornadasCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public DeleteModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Jornada Jornadas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jornadas = await _context.Jornadas.FirstOrDefaultAsync(m => m.Id == id);

            if (jornadas == null)
            {
                return NotFound();
            }
            else
            {
                Jornadas = jornadas;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jornadas = await _context.Jornadas.FindAsync(id);
            if (jornadas != null)
            {
                Jornadas = jornadas;
                _context.Jornadas.Remove(Jornadas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
