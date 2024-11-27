using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Testare.Data;
using Proiect_Testare.Models;

namespace Proiect_Testare.Pages.Appointments
{
    public class CreateModel : AppointmentCategoriesPageModel
    {
        private readonly Proiect_Testare.Data.Proiect_TestareContext _context;

        public CreateModel(Proiect_Testare.Data.Proiect_TestareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "ID","Name");

            var appointment = new Appointment();
            appointment.AppointmentCategories = new List<AppointmentCategory>();

            PopulateAssignedCategoryData(_context, appointment);

            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newAppointment = new Appointment();
            if (selectedCategories != null)
            {
                newAppointment.AppointmentCategories = new List<AppointmentCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new AppointmentCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newAppointment.AppointmentCategories.Add(catToAdd);
                }
            }

            Appointment.AppointmentCategories = newAppointment.AppointmentCategories;
            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
