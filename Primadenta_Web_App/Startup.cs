using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Primadenta_Web_App.Startup))]
namespace Primadenta_Web_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
