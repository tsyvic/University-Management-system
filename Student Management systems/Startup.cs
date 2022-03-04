using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Student_Management_systems.Models;

[assembly: OwinStartupAttribute(typeof(Student_Management_systems.Startup))]
namespace Student_Management_systems
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
