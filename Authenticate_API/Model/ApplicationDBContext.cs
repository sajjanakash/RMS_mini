using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authenticate_API.Model
{
    public class ApplicationDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=RMS_DB; Trusted_Connection=True; MultipleActiveResultsets=True");
        }

        public DbSet<UserInfo> Employees { get; set; }
    }
}
