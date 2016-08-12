using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nastani.Startup))]
namespace Nastani
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
