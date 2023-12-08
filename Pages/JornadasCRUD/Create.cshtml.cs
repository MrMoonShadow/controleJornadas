using controleJornadas.Data;
using controleJornadas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace controleJornadas.Pages.JornadasCRUD
{
    public class CreateModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext context = context;

        public IActionResult OnGet()
        {
            this.Erro = false;
            this.Message = null;
            ViewData["Funcionarios"] = new SelectList(this.context.Funcionarios, "Id", "Nome");
            return Page();
        }

        [BindProperty]
        public Jornada Jornada { get; set; } = default!;

        [BindProperty]
        public bool Erro { get; set; } = false;

        [BindProperty]
        public string? Message { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                ModelState.ClearValidationState(nameof(Jornada));
                if (!base.TryValidateModel(Jornada, nameof(Jornada)))
                {
                    throw new Exception("Jornada inválida");
                }
                else
                {
                    this.context.Jornadas.Add(Jornada);
                    await this.context.SaveChangesAsync();

                    return base.RedirectToPage("./Index");
                }
            }
            catch (Exception ex)
            {
                this.Erro = true;
                this.Message = ex.Message;
                return Page();
            }
        }
    }
}
