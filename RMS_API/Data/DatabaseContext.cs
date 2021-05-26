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
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

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
