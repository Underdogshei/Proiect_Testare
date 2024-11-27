using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Testare.Data;
using Proiect_Testare.Models;

namespace Proiect_Testare.Pages.Owners
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Testare.Data.Proiect_TestareContext _context;

        public IndexModel(Proiect_Testare.Data.Proiect_TestareContext context)
        {
            _context = context;
        }

        public IList<Owner> Owner { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Owner = await _context.Owner.ToListAsync();
        }
    }
}
