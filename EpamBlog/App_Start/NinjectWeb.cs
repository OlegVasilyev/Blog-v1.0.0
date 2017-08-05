[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EpamBlog.App_Start.NinjectWeb), "Start")]

namespace EpamBlog.App_Start
{
    using global::Ninject.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    public static class NinjectWeb 
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
