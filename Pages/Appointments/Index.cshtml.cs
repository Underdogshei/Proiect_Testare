using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Testare.Data;
using Proiect_Testare.Models;

namespace Proiect_Testare.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Testare.Data.Proiect_TestareContext _context;

        public IndexModel(Proiect_Testare.Data.Proiect_TestareContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;
        public AppointmentData AppointmentD { get; set; }
        public int AppointmentID { get; set; }
        public int CategoryID { get; set; }
        public string VehicleSort { get; set; }
        public string OwnerSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            AppointmentD = new AppointmentData();

            VehicleSort = String.IsNullOrEmpty(sortOrder) ? "vehicle_desc" : "";
            OwnerSort = sortOrder == "owner" ? "owner_desc" : "owner";

            CurrentFilter = searchString;

            AppointmentD.Appointments = await _context.Appointment
                  .Include(b => b.Owner)
                  .Include(b => b.AppointmentCategories)
                  .ThenInclude(b => b.Category)
                  .AsNoTracking()
                  .OrderBy(b => b.Vehicle)
                  .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                AppointmentD.Appointments = AppointmentD.Appointments.Where(s => s.Owner.Name.Contains(searchString)

          || s.Owner.Name.Contains(searchString)
          || s.Vehicle.Contains(searchString));
            }

            if (id != null)
            {
                AppointmentID = id.Value;
                Appointment appointment = AppointmentD.Appointments
                    .Where(i => i.ID == id.Value).Single();
                AppointmentD.Categories = appointment.AppointmentCategories.Select(s => s.Category);
            }

            switch (sortOrder)
            {
                case "vehicle_desc":
                    AppointmentD.Appointments = AppointmentD.Appointments.OrderByDescending(s => s.Vehicle);
                    break;
                case "owner_desc":
                    AppointmentD.Appointments = AppointmentD.Appointments.OrderByDescending(s =>s.Owner.Name);
                    break;
                case "owner":
                    AppointmentD.Appointments = AppointmentD.Appointments.OrderBy(s =>s.Owner.Name);
                    break;
                default:
                    AppointmentD.Appointments = AppointmentD.Appointments.OrderBy(s => s.Vehicle);
                    break;



            }

        }
    }
}
