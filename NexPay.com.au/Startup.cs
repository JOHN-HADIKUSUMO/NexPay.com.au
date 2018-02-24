using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NexPay.com.au.Startup))]
namespace NexPay.com.au
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
