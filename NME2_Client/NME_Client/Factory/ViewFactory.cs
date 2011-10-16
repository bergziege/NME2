using NME2.UI.AboutScreen.Controller;
using NME2.UI.AboutScreen.Controller.Implementation;
using NME2.UI.AboutScreen.View.Implementation;
using NME2.UI.MainScreen.Controller;
using NME2.UI.MainScreen.Controller.Implementation;
using NME2.UI.MainScreen.View.Implementation;

namespace NME2.Factory
{
    public static class ViewFactory
    {
        public static IMainViewController GetMainView()
        {
            return new MainViewController(new MainView());
        }

        public static  IAboutViewController GetAboutView()
        {
            return new AboutViewController(new AboutView());
        }
    }
}