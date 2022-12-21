using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Template_read.Startup))]
namespace MVC_Template_read
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
