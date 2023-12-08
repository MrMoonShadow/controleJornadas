using controleJornadas.Data;
using controleJornadas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace controleJornadas.Pages.FuncionariosCrud
{
    public class CreateModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext context = context;

        public IActionResult OnGet()
        {
            this.Erro = false;
            this.Message = null;
            ViewData["Bases"] = new SelectList(this.context.Bases, "Id", "Sigla");
            return Page();
        }

        [BindProperty]
        public Funcionario Funcionario { get; set; } = default!;

        [BindProperty]
        public bool Erro { get; set; } = false;

        [BindProperty]
        public string? Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                ModelState.ClearValidationState(nameof(Funcionario));
                if (!TryValidateModel(Funcionario, nameof(Funcionario)))
                {
                    throw new Exception("Funcionário inválido");
                }
                else
                {
                    this.context.Funcionarios.Add(Funcionario);
                    await this.context.SaveChangesAsync();

                    return RedirectToPage("./Index");
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
