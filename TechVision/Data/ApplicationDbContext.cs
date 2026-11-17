using Microsoft.EntityFrameworkCore;
using TechVision.Models;

namespace TechVision.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Service> Services => Set<Service>();
    public DbSet<News> News => Set<News>();
    public DbSet<AdminUser> AdminUsers => Set<AdminUser>();
    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();
}