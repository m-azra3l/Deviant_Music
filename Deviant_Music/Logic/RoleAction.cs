using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deviant_Music.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Deviant_Music.Logic
{
    internal class  RoleAction
    {
        internal void createAdmin()
        {
            // Access the application context and create result variables.
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;
           

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, you create the "Administrator" role if it doesn't already exist.
            if (!roleMgr.RoleExists("Administrator Level1"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("Administrator Level1"));
                if (!IdRoleResult.Succeeded)
                {
                    // Handle the error condition if there's a problem creating the RoleManager object.
                }
            }

            if (!roleMgr.RoleExists("Administrator Level2"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("Administrator Level2"));
                if (!IdRoleResult.Succeeded)
                {
                    // Handle the error condition if there's a problem creating the RoleManager object.
                }
            }

            if (!roleMgr.RoleExists("SuperAdministrator"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("SuperAdministrator"));
                if (!IdRoleResult.Succeeded)
                {

                }
            }
            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser()
            {
                Email = "deviantmusicng@gmail.com", UserName="superadmin",
            };
            IdUserResult = userMgr.Create(appUser, "password1");

            // If the new "Admin" user was successfully created, 
            // add the "Admin" user to the "Administrator" role. 
            if (IdUserResult.Succeeded)
            {
                IdUserResult = userMgr.AddToRole(appUser.Id, "SuperAdministrator");
                if (!IdUserResult.Succeeded)
                {
                    // Handle the error condition if there's a problem adding the user to the role.
                }
            }
            else
            {
                // Handle the error condition if there's a problem creating the new user. 
            }

            var userMgr1 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser1 = new ApplicationUser()
            {
                Email = "level1@mail.com",
                UserName = "level1admin",
            };
            IdUserResult = userMgr1.Create(appUser1, "password1");

            // If the new "Admin" user was successfully created, 
            // add the "Admin" user to the "Administrator" role. 
            if (IdUserResult.Succeeded)
            {
                IdUserResult = userMgr1.AddToRole(appUser1.Id, "Administrator Level1");
                if (!IdUserResult.Succeeded)
                {
                    // Handle the error condition if there's a problem adding the user to the role.
                }
            }
            else
            {
                // Handle the error condition if there's a problem creating the new user. 
            }
            var userMgr2 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser2 = new ApplicationUser()
            {
                Email = "level2@mail.com",
                UserName = "level2admin",
            };
            IdUserResult = userMgr.Create(appUser2, "password1");

            // If the new "Admin" user was successfully created, 
            // add the "Admin" user to the "Administrator" role. 
            if (IdUserResult.Succeeded)
            {
                IdUserResult = userMgr2.AddToRole(appUser2.Id, "Administrator Level2");
                if (!IdUserResult.Succeeded)
                {
                    // Handle the error condition if there's a problem adding the user to the role.
                }
            }
            else
            {
                // Handle the error condition if there's a problem creating the new user. 
            }
        }
   }
}
