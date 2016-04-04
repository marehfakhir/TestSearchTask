using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_Search_Task.Startup))]
namespace Test_Search_Task
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
