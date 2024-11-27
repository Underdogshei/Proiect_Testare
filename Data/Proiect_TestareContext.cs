using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Testare.Models;

namespace Proiect_Testare.Data
{
    public class Proiect_TestareContext : DbContext
    {
        public Proiect_TestareContext (DbContextOptions<Proiect_TestareContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Testare.Models.Appointment> Appointment { get; set; } = default!;
        public DbSet<Proiect_Testare.Models.Category> Category { get; set; } = default!;
        public DbSet<Proiect_Testare.Models.Owner> Owner { get; set; } = default!;
    }
}
