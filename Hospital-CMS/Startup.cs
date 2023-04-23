using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hospital_CMS.Startup))]
namespace Hospital_CMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
