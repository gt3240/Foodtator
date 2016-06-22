using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Foodtator.Startup))]
namespace Foodtator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
