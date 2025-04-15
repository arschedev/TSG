using Microsoft.EntityFrameworkCore;

namespace backend.Classes;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<StudentForm> Forms => Set<StudentForm>();
}