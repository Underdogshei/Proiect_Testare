using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Testare.Data;

namespace Proiect_Testare.Models
{
    public class AppointmentCategoriesPageModel : PageModel
    {

        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Proiect_TestareContext context, Appointment appointment)
        {
            var allCategories = context.Category;
            var appointmentCategories = new HashSet<int>(appointment.AppointmentCategories.Select(c => c.CategoryID)); // 
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = appointmentCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateAppointmentCategories(Proiect_TestareContext context,
            string[] selectedCategories, Appointment appointmentToUpdate)
        {
            if (selectedCategories == null)
            {
                appointmentToUpdate.AppointmentCategories = new List<AppointmentCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var appointmentCategories = new HashSet<int>
                (appointmentToUpdate.AppointmentCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!appointmentCategories.Contains(cat.ID))
                    {
                        appointmentToUpdate.AppointmentCategories.Add(
                            new AppointmentCategory
                            {
                                AppointmentID = appointmentToUpdate.ID,
                                CategoryID = cat.ID
                            });
                    }
                }
                else
                {
                    if (appointmentCategories.Contains(cat.ID))
                    {
                        AppointmentCategory appointmentToRemove
                            = appointmentToUpdate
                                .AppointmentCategories
                                .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(appointmentToRemove);
                    }
                }
            }
        }
    }
}
