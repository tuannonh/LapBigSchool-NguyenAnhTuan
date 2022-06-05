using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LapBigSchool_NguyenAnhTuan.Startup))]
namespace LapBigSchool_NguyenAnhTuan
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
