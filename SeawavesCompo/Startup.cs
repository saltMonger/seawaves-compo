using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

using SeawavesCompo.DataAccess;
using SeawavesCompo.Models;

[assembly: OwinStartupAttribute(typeof(SeawavesCompo.Startup))]
namespace SeawavesCompo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUsersAndRoles();
        }

        public void CreateUsersAndRoles()
        {
            //configure identites
            ApplicationDbContext context = new ApplicationDbContext();
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //TODO: Switch to enumeration checking
            if (!roleManager.RoleExists("ADMIN"))
            {
                //create admin role
                var role = new IdentityRole();
                role.Name = "ADMIN";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("USER"))
            {
                var role = new IdentityRole()
                {
                    Name = "USER",
                };
                roleManager.Create(role);
            }

        }
    }
}
