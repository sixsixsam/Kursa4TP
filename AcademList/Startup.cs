using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcademList.Startup))]
namespace AcademList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
