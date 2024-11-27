using System.ComponentModel.DataAnnotations;

namespace Proiect_Testare.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Categoriile")]
        public string CategoryName { get; set; }

        public ICollection<AppointmentCategory>? AppointmentCategories { get; set; }
    }
}
