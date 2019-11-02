using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReinforceAuth.Startup))]
namespace ReinforceAuth
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
