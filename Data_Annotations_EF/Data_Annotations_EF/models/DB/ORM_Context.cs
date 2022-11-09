using Microsoft.EntityFrameworkCore;
using static Data_Annotations_EF.models.DB.ORM_Manager;

namespace Data_Annotations_EF.models.DB;
public class ORM_Context : DbContext
    {
        public virtual DbSet<Evaluation> Evaluations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evaluation>()
                .Property(eid => eid.EvaluationId)
                .HasColumnName("Id")
                .HasDefaultValue(0)
                .IsRequired();
            modelBuilder.Entity<Evaluation>()
                .Property(t => t.Evaluation_Text)
                .HasColumnName("Evaluation_Text")
                .HasDefaultValue(null)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string constring = $"Server=localhost;database=orm_test_5a;user=root;password=SHW_Destroyer02";
        optionsBuilder.UseSqlServer(constring);
    }
}