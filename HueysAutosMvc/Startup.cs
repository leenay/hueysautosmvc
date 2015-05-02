using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HueysAutosMvc.Startup))]
namespace HueysAutosMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
