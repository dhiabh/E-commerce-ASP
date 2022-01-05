using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_commerce_ASP.Startup))]
namespace E_commerce_ASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
