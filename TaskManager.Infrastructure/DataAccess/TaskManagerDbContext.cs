using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure.DataAccess
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) { }
        
        public DbSet<Domain.Entities.Task> Task { get; set; }
    }
}
