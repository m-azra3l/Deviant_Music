using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Deviant_Music.Startup))]
namespace Deviant_Music
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
