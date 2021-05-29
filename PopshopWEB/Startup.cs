using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PopshopWEB.Startup))]
namespace PopshopWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
        }
    }
}
