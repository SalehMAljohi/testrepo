using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using WebSiteTemplete.Models;

[assembly: OwinStartupAttribute(typeof(WebSiteTemplete.Startup))]
namespace WebSiteTemplete
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();

        }
        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("admin"))
            {
                role.Name = "admin";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "NOAH";
                user.Email = "salehaljohi33@gmail.com";
                user.UserType = "admin";
                user.PhoneNumber = "0551513255";
                var check = userManager.Create(user, "Sa12345!");
                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "admin");
                }
            }
        }

    }
}
