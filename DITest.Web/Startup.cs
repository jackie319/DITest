using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DITest.Startup))]
namespace DITest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
