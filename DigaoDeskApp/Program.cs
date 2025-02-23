using System;
using System.Threading;
using System.Windows.Forms;

namespace DigaoDeskApp
{
    static class Program
    {

        static Mutex mutex = new Mutex(true, "DigaoDeskApp");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                Messages.Error("Digao Desk is already running!");
                return;
            }

            Vars.FrmMainObj = new();
            Application.Run(Vars.FrmMainObj);
        }

    }
}
