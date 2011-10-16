using System;
using NME2_Server_Manager.Factory;
using NME2_Server_Manager.MainWindow.Controller;
using NME2_Server_Manager.MainWindow.Controller.Implementation;

namespace NME2_Server_Manager {
    class Program {
        [STAThread]
        static void Main() {
            App app = new App();
            IMainWindowController controller = WindowControllerFactory.GetMainWindowController();
            app.Run(controller.GetAttachedWindow().GetAsWindow());
        }
    }
}
