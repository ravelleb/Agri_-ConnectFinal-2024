using Microsoft.AspNetCore.Identity;
using Agri__ConnectFinal.Constants;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Agri__ConnectFinal.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider serviceProvider)
        {
            var userMgr = serviceProvider.GetService<UserManager<IdentityUser>>();
            var roleMgr = serviceProvider.GetService<RoleManager<IdentityRole>>();

            var roles = Enum.GetNames(typeof(Roles));

            foreach (var role in roles)
            {
                if (!await roleMgr.RoleExistsAsync(role))
                {
                    await roleMgr.CreateAsync(new IdentityRole(role));
                }
            }

            var adminEmail = "admin@example.com";
            var adminUser = await userMgr.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                var createAdminResult = await userMgr.CreateAsync(adminUser, "AdminPassword123!");
                if (createAdminResult.Succeeded)
                {
                    await userMgr.AddToRoleAsync(adminUser, Roles.Admin.ToString());
                }
            }

            var employeeEmail = "employee@example.com";
            var employeeUser = await userMgr.FindByEmailAsync(employeeEmail);

            if (employeeUser == null)
            {
                employeeUser = new IdentityUser { UserName = employeeEmail, Email = employeeEmail, EmailConfirmed = true };
                var createEmployeeResult = await userMgr.CreateAsync(employeeUser, "EmployeePassword123!");
                if (createEmployeeResult.Succeeded)
                {
                    await userMgr.AddToRoleAsync(employeeUser, Roles.Employee.ToString());
                }
            }
        }
    }
}
