using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToDoApp.Startup))]
namespace ToDoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
