using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_Examen_03.Startup))]
namespace Web_Examen_03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
