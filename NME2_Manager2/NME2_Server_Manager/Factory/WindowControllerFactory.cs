using NME2_Server_Manager.MainWindow.Controller;
using NME2_Server_Manager.MainWindow.Controller.Implementation;

namespace NME2_Server_Manager.Factory {
    class WindowControllerFactory {
        public static IMainWindowController GetMainWindowController() {
            return new MainWindowController(new MainWindow.Window.Implementation.MainWindow());
        }
    }
}
