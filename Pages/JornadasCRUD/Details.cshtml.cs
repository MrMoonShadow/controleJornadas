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
    public class DetailsModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext _context = context;

        public Jornada Jornadas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jornadas = await _context.Jornadas.Include(x => x.Funcionario).FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
