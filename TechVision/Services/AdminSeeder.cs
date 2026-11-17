using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechVision.Data;
using TechVision.Models;

namespace TechVision.Services;

public static class AdminSeeder
{
    public static async Task SeedAsync(
        IDbContextFactory<ApplicationDbContext> factory)
    {
        await using var db = await factory.CreateDbContextAsync();

        if (await db.AdminUsers.AnyAsync())
            return;

        var admin = new AdminUser
        {
            Username = "admin"
        };

        var hasher = new PasswordHasher<AdminUser>();
        admin.PasswordHash = hasher.HashPassword(admin, "ChangeMe123!");

        db.AdminUsers.Add(admin);
        await db.SaveChangesAsync();
    }
}