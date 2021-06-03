using Microsoft.EntityFrameworkCore;
using RMS_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMS_API.Data
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=RMS_DB; Trusted_Connection=True; MultipleActiveResultsets=True");
        }

       
        public DbSet<Employee> Employees { get; set; }
    }
}
