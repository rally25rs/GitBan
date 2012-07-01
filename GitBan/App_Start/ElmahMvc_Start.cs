[assembly: WebActivator.PreApplicationStartMethod(typeof(GitBan.App_Start.ElmahMvc), "Start")]
namespace GitBan.App_Start
{
    public class ElmahMvc
    {
        public static void Start()
        {
            Elmah.Mvc.Bootstrap.Initialize();
        }
    }
}