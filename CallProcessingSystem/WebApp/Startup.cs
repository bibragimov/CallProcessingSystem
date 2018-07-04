using Microsoft.Owin;
using Owin;
using SimpleInjector;
using WebApp;

[assembly: OwinStartup(typeof(Startup))]

namespace WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = new Container();
            SimpleInjectorConfiguration.Configure(container);
            ConfigureAuth(app);
        }
    }
}