using System;
using Microsoft.AspNetCore.Identity;

namespace ClinicApp.Helpers;

public class AdminSeeder
{
    public static async Task SeedAdminUser(WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        var admin = await userManager.FindByEmailAsync("admin@clinic.demo");
        
        if (admin != null)
        {
            return;
        }

        admin = new IdentityUser
        {
            Email = "admin@clinic.demo",
            UserName = "admin@clinic.demo"
        };

        var result = await userManager.CreateAsync(admin, "Admin@123456");

        if (!result.Succeeded)
        {
            throw new Exception("Admin can't be created");
        }

        result = await userManager.AddToRoleAsync(admin, AppRoles.APP_ADMIN.ToString());
        if (!result.Succeeded)
        {
            throw new Exception("Admin can't be created");
        }
        
        System.Console.WriteLine("Admin user created!!");
    } 
}
