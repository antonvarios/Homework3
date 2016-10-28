using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Homework3.Startup))]
namespace Homework3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
