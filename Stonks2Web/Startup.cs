using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using Stonks2.StockBot;

[assembly: OwinStartupAttribute(typeof(Stonks2Web.Startup))]
namespace Stonks2Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            GlobalHost.DependencyResolver.Register(
            typeof(ChatHub), () => new ChatHub(new StockBot()));

            app.MapSignalR();
        }
    }
}
