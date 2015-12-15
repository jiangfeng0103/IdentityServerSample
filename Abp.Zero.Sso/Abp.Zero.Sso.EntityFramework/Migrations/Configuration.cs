using Abp.Zero.Sso.Authorization.Users;
using Microsoft.AspNet.Identity;

namespace Abp.Zero.Sso.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Abp.Zero.Sso.EntityFramework.SsoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Abp.Zero.Sso.EntityFramework.SsoDbContext context)
        {
            #region 用户
            if (!context.Users.Any())
            {
                context.Users.Add(
                    new User
                    {
                        TenantId = null,
                        UserName = User.AdminUserName,
                        Name = "一统",
                        Surname = "张",
                        EmailAddress = "username@126.com",
                        IsEmailConfirmed = true,
                        ShouldChangePasswordOnNextLogin = false,
                        IsActive = true,
                        Password = new PasswordHasher().HashPassword("admina")
                    });
                context.SaveChanges();
            }

            #endregion
        }
    }
}
