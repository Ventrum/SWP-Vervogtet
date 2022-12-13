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
        //public ConstringManager cm = new ConstringManager();
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Additional> Additionals { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarBill> CarsBill { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = $"Server=localhost;database=autovermietung;user=swp-vogt;password=swp-vogt";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
