using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proyecto4.Startup))]
namespace Proyecto4
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
