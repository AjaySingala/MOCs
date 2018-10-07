using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(20533D0502MobileAppService.Startup))]

namespace 20533D0502MobileAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}