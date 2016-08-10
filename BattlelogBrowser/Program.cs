using CefSharp;
using System;
using System.Windows.Forms;

namespace Alexantr.BattlelogBrowser
{
    static class Program
    {
        public static string appName = "Battlelog Browser";
        public static string homeUrl = "http://battlelog.battlefield.com/";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Upgrade Application Settings if applicable
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(new CefSettings { CachePath = "cache" }, shutdownOnProcessExit: false, performDependencyCheck: true);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BrowserForm());
        }
    }
}
