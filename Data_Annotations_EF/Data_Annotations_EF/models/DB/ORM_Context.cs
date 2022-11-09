using Microsoft.EntityFrameworkCore;

namespace Data_Annotations_EF.models.DB;

public class ORM_Context : DbContext
    {

    // DbSet<Klassenname> ermöglicht den Zugriff auf die DB-Tabelle Customers
    public virtual DbSet<Evaluation> Evaluations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string constring = "Server=localhost;database=orm_test_5a;user=root;password=SHW_Destroyer02";
        optionsBuilder.UseSqlServer(constring);
    }
}