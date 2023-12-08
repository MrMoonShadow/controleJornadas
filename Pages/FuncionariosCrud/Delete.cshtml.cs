using controleJornadas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace controleJornadas.Pages.FuncionariosCrud
{
    public class DeleteModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public DeleteModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Funcionario funcionarios { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios.FirstOrDefaultAsync(m => m.Id == id);

            if (funcionarios == null)
            {
                return NotFound();
            }
            else
            {
                this.funcionarios = funcionarios;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios.FindAsync(id);
            if (funcionarios != null)
            {
                this.funcionarios = funcionarios;
                _context.Funcionarios.Remove(funcionarios);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
