using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab_2._5.Models;

namespace lab_2._5.Data
{
    public class lab_2_5Context : DbContext
    {
        public lab_2_5Context (DbContextOptions<lab_2_5Context> options)
            : base(options)
        {
        }

        public DbSet<lab_2._5.Models.HospitalsModel>? HospitalsModel { get; set; }

        public DbSet<lab_2._5.Models.LabsModel> LabsModel { get; set; }

        public DbSet<lab_2._5.Models.DoctorsModel> DoctorsModel { get; set; }

        public DbSet<lab_2._5.Models.PatientsModel> PatientsModel { get; set; }
    }
}
