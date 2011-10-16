using System;
using System.Windows.Forms;
using NME2.Factory;

namespace NME2
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(ViewFactory.GetMainView().GetAttachedView().GetAsForm());
        }
    }
}
