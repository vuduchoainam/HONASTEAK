using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HONASTEAK.Startup))]
namespace HONASTEAK
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
