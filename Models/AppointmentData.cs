﻿namespace Proiect_Testare.Models
{
    public class AppointmentData
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<AppointmentCategory> AppointmentCategories { get; set; }
    }
}
