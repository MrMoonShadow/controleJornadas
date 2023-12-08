using controleJornadas.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace controleJornadas.Pages.FuncionariosCrud
{
    public class IndexModel(Data.ApplicationDbContext context) : PageModel
    {
        private readonly Data.ApplicationDbContext context = context;

        public IList<Funcionario> funcionarios { get;set; } = default!;

        public async Task OnGetAsync()
        {
            this.funcionarios = await this.context.Funcionarios.Include(a =>a.Base).ToListAsync();
        }
    }
}
