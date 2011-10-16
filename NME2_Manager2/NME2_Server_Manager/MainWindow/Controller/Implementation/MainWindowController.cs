using NME2_Server_Manager.Interface;
using NME2_Server_Manager.MainWindow.Window;

namespace NME2_Server_Manager.MainWindow.Controller.Implementation {
    class MainWindowController:IMainWindowController {
        private IMainWindow _attachedWindow;

        public MainWindowController(IMainWindow attachedWindow) {
            this._attachedWindow = attachedWindow;
        }

        #region Implementation of IBaseWindowController

        public IBaseWindow GetAttachedWindow() {
            return _attachedWindow;
        }

        #endregion
    }
}
