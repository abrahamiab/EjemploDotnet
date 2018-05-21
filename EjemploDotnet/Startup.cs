using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EjemploDotnet.Startup))]
namespace EjemploDotnet
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
