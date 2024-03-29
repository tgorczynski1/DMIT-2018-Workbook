﻿using DemoSystem.BLL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;
using static WebApp.Admin.Security.Settings;

// You can learn about Database Initialization Strategies in EF6 via
// http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx

namespace WebApp.Admin.Security
{
    /// <summary>
    /// Provide functionality for setting up the database for the ApplicationDbContext.
    /// The specific functionality is to create the database if it does not exist.
    /// </summary>
    public class SecurityDbContextInitializer
        : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // To "seed" a database is to provide it with some initial data
            // when the database is created.

            #region Seed the security roles
            // Make the Identity's BLL instance to help us manage roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            // The RoleManager<T> and RoleStore<T> are BLL classes that give flexibility
            // to the design/structure of how we're using Asp.NET Identity.
            // The IdentityRole is an Entity class that represents a security role.

            foreach(var role in DefaultSecurityRoles)
                roleManager.Create(new IdentityRole { Name = role });
            #endregion

            #region Seed the users
            var adminUser = new ApplicationUser
            {
                UserName = AdminUserName,
                Email = AdminEmail,
                EmailConfirmed = true
            };
            #endregion
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var result = userManager.Create(adminUser, AdminPassword);
            if (result.Succeeded)
            {
                var adminId = userManager.FindByName(AdminUserName).Id;

                userManager.AddToRole(adminId, AdminRole);
            }

            var demoManager = new DemoController();
            var people = demoManager.ListPeople();
            foreach(var person in people)
            {
                var user = new ApplicationUser
                {
                    UserName = $"{person.FirstName}.{person.LastName}",
                    Email = $"{person.FirstName}.{person.LastName}@DemoIsland.com",
                    EmailConfirmed = true,
                    PersonId = person.PersonID
                };
                result = userManager.Create(user, TempPassword);
                if (result.Succeeded)
                {
                    var userId = userManager.FindByName(user.UserName).Id;
                    userManager.AddToRole(userId, UserRole);
                }
            }

            // Note: Keep this call to the base class so it can do its seeding work
            base.Seed(context);
        }
    }
}