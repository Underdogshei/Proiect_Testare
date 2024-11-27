using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Testare.Models;
using Proiect_Testare.Data;
using Proiect_Testare.Models;

namespace Proiect_Testare.Pages.Appointments
{
    public class EditModel : AppointmentCategoriesPageModel
    {
        private readonly Proiect_Testare.Data.Proiect_TestareContext _context;

        public EditModel(Proiect_Testare.Data.Proiect_TestareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment = await _context.Appointment
             .Include(b => b.AppointmentCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);


            var appointment = await _context.Appointment.FirstOrDefaultAsync(m => m.ID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Appointment);

            Appointment = appointment;
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var appointmentToUpdate = await _context.Appointment
            .Include(i => i.AppointmentCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (appointmentToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Appointment>(
               appointmentToUpdate,
               "Appointment",
               i => i.Vehicle, i => i.Owner,
                i => i.Price, i => i.Validity, i => i.InspectionDate, i => i.ExpiractionDate))
            {
                UpdateAppointmentCategories(_context, selectedCategories, appointmentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateAppointmentCategories(_context, selectedCategories, appointmentToUpdate);
            PopulateAssignedCategoryData(_context, appointmentToUpdate);
            return Page();
        }
    }
}
