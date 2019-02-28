using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagEmpDataModel
{
    public class SagEmployeeDbContext : DbContext
    {
        public DbSet<busSagEmployee> employees { get; set; }
        public DbSet<busSagLocation> locations { get; set; }

    }
}
