using System.Web.Mvc;
using GitBan.App_Start;
using GitBan.Infrastructure.DependencyResolution;
using WebActivator;

[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]

namespace GitBan.App_Start
{
    public static class StructuremapMvc
    {
        public static void Start()
        {
            var container = IoC.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}