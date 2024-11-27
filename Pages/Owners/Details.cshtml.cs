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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Testare.Data.Proiect_TestareContext _context;

        public DetailsModel(Proiect_Testare.Data.Proiect_TestareContext context)
        {
            _context = context;
        }

        public Owner Owner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _context.Owner.FirstOrDefaultAsync(m => m.ID == id);
            if (owner == null)
            {
                return NotFound();
            }
            else
            {
                Owner = owner;
            }
            return Page();
        }
    }
}
