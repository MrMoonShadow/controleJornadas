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
    public class IndexModel : PageModel
    {
        private readonly controleJornadas.Data.ApplicationDbContext _context;

        public IndexModel(controleJornadas.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Base> Bases { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Bases = await _context.Bases.ToListAsync();
        }
    }
}
