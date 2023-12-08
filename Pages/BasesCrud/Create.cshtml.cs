using controleJornadas.Data;
using controleJornadas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace controleJornadas.Pages.BasesCrud
{
    public class CreateModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext context = context;

        public IActionResult OnGet()
        {
            this.Erro = false;
            this.Message = null;
            return Page();
        }

        [BindProperty]
        public Base Base { get; set; } = default!;

        [BindProperty]
        public bool Erro { get; set; } = false;

        [BindProperty]
        public string? Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                ModelState.ClearValidationState(nameof(Base));
                if (!TryValidateModel(Base, nameof(Base)))
                {
                    throw new Exception("Base inválida");
                }
                else
                {
                    await this.context.Bases.AddAsync(Base);
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
