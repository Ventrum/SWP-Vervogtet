using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autovermietung.models.DB
{
    public class DBManager : DbContext
    {
        public ConstringManager cm = new ConstringManager();
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarBill> CarBills { get; set; }
        public virtual DbSet<Additional> Additionals { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Server={cm.Server};database={cm.Database};user={cm.User};password={cm.Pw}";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
