using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotel.Atr.Web.Startup))]
namespace Hotel.Atr.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
