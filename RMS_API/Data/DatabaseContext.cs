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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(b => b.Employee)
                .WithMany(ba => ba.EmployeeSkill)
                .HasForeignKey(bi => bi.EmpId);
                

            modelBuilder.Entity<EmployeeSkill>()
              .HasOne(b => b.Skill)
              .WithMany(ba => ba.EmployeeSkill)
              .HasForeignKey(bi => bi.SkillSet);

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkill { get; set; }
    }
}
