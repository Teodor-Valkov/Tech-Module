using HireOrRent.Migrations;
using HireOrRent.Models;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(HireOrRent.Startup))]
namespace HireOrRent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            ConfigureAuth(app);
        }
    }
}
