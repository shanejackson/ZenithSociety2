using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithWebsite.Models
{
    public class UserSeedData
    {
        public static async Task Initialize(ZenithContext db, IServiceProvider serviceProvider) {
            await createRoles(db, serviceProvider);
            await createUsers(db, serviceProvider);
            db.SaveChanges();
        }

        private static async Task createRoles(ZenithContext context, IServiceProvider services) {
            var RoleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            if (!context.Roles.Any(r => r.Name == "Admin")) {
                await RoleManager.CreateAsync(new IdentityRole {
                    Name = "Admin",
                });
            }

            if (!context.Roles.Any(r => r.Name == "Member")) {
                await RoleManager.CreateAsync(new IdentityRole {
                    Name = "Member",
                });
            }
        }

        private static async Task createUsers(ZenithContext context, IServiceProvider services) {
            var UserManager = services.GetRequiredService<UserManager<IdentityUser>>();

            var user1 = new ApplicationUser {
                UserName = "a",
                Email = "a@a.a"
            };

            var user2 = new ApplicationUser {
                UserName = "m",
                Email = "m@m.m"
            };

            if (!context.Users.Any(u => u.UserName == user1.UserName) && !context.Users.Any(u => u.UserName == user2.UserName)) {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed1 = password.HashPassword(user1, "P@$$w0rd");
                user1.PasswordHash = hashed1;
                await UserManager.CreateAsync(user1);
                await UserManager.AddToRoleAsync(user1, "Admin");

                var hashed2 = password.HashPassword(user2, "P@$$w0rd");
                user2.PasswordHash = hashed2;
                var userStore = new UserStore<ApplicationUser>(context);
                await UserManager.CreateAsync(user2);
                await UserManager.AddToRoleAsync(user2, "Member");
            }
        }
    }
}
