using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentTrackASP.Net.Startup))]
namespace StudentTrackASP.Net
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
