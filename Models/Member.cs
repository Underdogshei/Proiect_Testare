using System.ComponentModel.DataAnnotations;
namespace Proiect_Testare.Models
{
    public class Member
    {
        public int ID { get; set; }

        [Display(Name = "Nume")]
        public string? Name { get; set; }

        [Display(Name = "Adresă")]
        public string? Adress { get; set; }

        public string Email { get; set; }

        [Display(Name = "Telefon")]
        public string? Phone { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
