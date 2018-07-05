using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hotel.Atr.Admin.Startup))]
namespace Hotel.Atr.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
