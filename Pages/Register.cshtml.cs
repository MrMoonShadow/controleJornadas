using controleJornadas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace controleJornadas.Pages
{
    public class RegisterModel(UserManager<Usuario> userManager) : PageModel
    {
        private readonly UserManager<Usuario> userManager = userManager;

        [BindProperty]
        public string? Usuario { get; set; }

        [BindProperty]
        public string? Senha { get; set; }

        [BindProperty]
        public string? ConfirmarSenha { get; set; }

        [BindProperty]
        public bool Erro { get; set; } = false;

        [BindProperty]
        public string? Message { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var result = await this.userManager.CreateAsync(new()
                {
                    Email = this.Usuario,
                    UserName = this.Usuario,
                }, this.Senha);

                if (result.Succeeded)
                {
                    return base.RedirectToPage("./Index");
                }
                else 
                {
                    throw new Exception(string.Join(';',result.Errors));
                }

                throw new Exception("Usuario ou senha incorretos.");
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
