using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stonks2Web.Startup))]
namespace Stonks2Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
