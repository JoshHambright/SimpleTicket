using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleTicket.MVC.Startup))]
namespace SimpleTicket.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
