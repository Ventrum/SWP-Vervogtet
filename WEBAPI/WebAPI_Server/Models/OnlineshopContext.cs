using Microsoft.EntityFrameworkCore;
using Onlineshop.Models;

namespace WebAPI_Server
{
    public class OnlineshopContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // für den Pomelo-MySQL-Treiber
            string connectionString = "Server=localhost;database=webapi;user=root;password=SHW_Destroyer02";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
