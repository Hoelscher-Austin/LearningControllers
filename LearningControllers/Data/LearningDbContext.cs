using LearningControllers.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningControllers.Data {
    public class LearningDbContext(DbContextOptions<LearningDbContext> options) : DbContext(options) {

        public DbSet<Student> Students { get; set; }
    }
}
