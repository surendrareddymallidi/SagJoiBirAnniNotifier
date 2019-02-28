using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SagEmpMaintenance.Startup))]
namespace SagEmpMaintenance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
