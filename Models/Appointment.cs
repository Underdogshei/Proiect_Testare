using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Testare.Models
{
    public class Appointment
    {
        public int ID { get; set; }

        [Display(Name = "Vehicul")]
        public string Vehicle { get; set; }

        [Display(Name = "Preț")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Valabilitate")]
        public int Validity { get; set; }

        [Display(Name = "Data Inspecției")]
        [DataType(DataType.Date)]
        public DateTime InspectionDate { get; set; }

        [Display(Name = "Data Expirării")]
        [DataType(DataType.Date)]
        public DateTime ExpiractionDate { get; set; }

        public int? OwnerID { get; set; }
        public Owner? Owner { get; set; }

        [Display(Name = "Categorie")]
        public ICollection<AppointmentCategory>? AppointmentCategories { get; set; }
    }
}
