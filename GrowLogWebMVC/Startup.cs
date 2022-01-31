using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrowLogWebMVC.Startup))]
namespace GrowLogWebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
