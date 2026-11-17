using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechVision.Data;
using TechVision.Models;

namespace TechVision.Pages;

public class AdminLoginModel : PageModel
{
    private readonly IDbContextFactory<ApplicationDbContext> _factory;

    public AdminLoginModel(
        IDbContextFactory<ApplicationDbContext> factory)
    {
        _factory = factory;
    }

    [BindProperty]
    public string Username { get; set; } = string.Empty;

    [BindProperty]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    public string? ReturnUrl { get; set; }

    public string? ErrorMessage { get; set; }

    public void OnGet(string? returnUrl = null)
    {
        ReturnUrl = returnUrl;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await using var db = await _factory.CreateDbContextAsync();

        var admin = await db.AdminUsers
            .FirstOrDefaultAsync(x => x.Username == Username);

        if (admin == null)
        {
            ErrorMessage = "Неправильний логін або пароль.";
            return Page();
        }

        var hasher = new PasswordHasher<AdminUser>();

        var result = hasher.VerifyHashedPassword(
            admin,
            admin.PasswordHash,
            Password);

        if (result == PasswordVerificationResult.Failed)
        {
            ErrorMessage = "Неправильний логін або пароль.";
            return Page();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, admin.Username),
            new(ClaimTypes.Role, "Admin")
        };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal);

        if (!string.IsNullOrWhiteSpace(ReturnUrl)
            && Url.IsLocalUrl(ReturnUrl))
        {
            return LocalRedirect(ReturnUrl);
        }

        return Redirect("/admin");
    }
}
