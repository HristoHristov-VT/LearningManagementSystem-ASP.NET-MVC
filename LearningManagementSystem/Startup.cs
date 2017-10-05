using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningManagementSystem.Startup))]
namespace LearningManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
