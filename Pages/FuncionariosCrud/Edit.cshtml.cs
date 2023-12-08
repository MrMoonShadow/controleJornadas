using controleJornadas.Data;
using controleJornadas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace controleJornadas.Pages.FuncionariosCrud
{
    public class EditModel(ApplicationDbContext context) : PageModel
    {
        private readonly ApplicationDbContext context = context;

        [BindProperty]
        public Funcionario Funcionario { get; set; } = default!;

        [BindProperty]
        public bool Erro { get; set; } = false;

        [BindProperty]
        public string? Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            this.Erro = false;
            this.Message = null;
            if (id is null)
            {
                return NotFound();
            }

            var funcionario = await this.context.Funcionarios.FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario is null)
            {
                return NotFound();
            }
            this.Funcionario = funcionario;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Erro ao editar Funcionário, entre em contato com o suporte.");
                }

                await context.Funcionarios.ExecuteUpdateAsync(funcionario => funcionario.SetProperty(p => p.Nome, this.Funcionario.Nome)
                                                                     .SetProperty(p => p.Cargo, this.Funcionario.Cargo)
                                                                     .SetProperty(p => p.DataAdmissao, this.Funcionario.DataAdmissao)
                                                                     .SetProperty(p => p.CodPix, this.Funcionario.CodPix));
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                this.Erro = true;
                this.Message = e.Message;
                return Page();
            }

            this.Message = "Funcionário salvo com sucesso!";

            return RedirectToPage("./Index");
        }
    }
}
