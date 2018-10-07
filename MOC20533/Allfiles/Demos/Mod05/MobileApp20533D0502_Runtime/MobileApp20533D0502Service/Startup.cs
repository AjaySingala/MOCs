using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MobileApp20533D0502Service.Startup))]

namespace MobileApp20533D0502Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}