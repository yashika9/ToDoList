using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormClient.Startup))]
namespace WebFormClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
