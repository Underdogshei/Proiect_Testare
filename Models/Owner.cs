using System.ComponentModel.DataAnnotations;

namespace Proiect_Testare.Models
{
    public class Owner
    {
        public int ID { get; set; }

        [Display(Name = "Nume")]
        public string Name { get; set; }

        [Display(Name = "Adresa")]
        public string? Adress { get; set; }

        [Display(Name = "Telefon")]
        [RegularExpression(@"^0\d{3}[-. ]?\d{3}[-. ]?\d{3}$", ErrorMessage = "Telefonul trebuie să înceapă cu 0 și să fie de forma '0722-123-123', '0722.123.123' sau '0722 123 123'")]
        public string? Phone { get; set; }
        public ICollection<Appointment>? Appointments { get; set; } 
    }
}
