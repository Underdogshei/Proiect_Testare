﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Testare.Data;
using Proiect_Testare.Models;

namespace Proiect_Testare.Pages.Owners
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Testare.Data.Proiect_TestareContext _context;

        public CreateModel(Proiect_Testare.Data.Proiect_TestareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Owner Owner { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Owner.Add(Owner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
