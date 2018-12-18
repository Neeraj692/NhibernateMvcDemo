using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NHibernateDemo.Startup))]
namespace NHibernateDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
