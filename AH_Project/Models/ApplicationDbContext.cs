using Microsoft.EntityFrameworkCore;
using AH_Project.Models.Entities;

namespace AH_Project.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<ModelCaption> ModelCaptions { get; set; } = null!;
        public DbSet<SimilarCaption> SimilarCaptions { get; set; } = null!;
        public DbSet<Evaluation> Evaluations { get; set; } = null!;

    }
}