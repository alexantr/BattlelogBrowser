using CefSharp;
using CefSharp.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace Alexantr.BattlelogBrowser
{
    static class Program
    {
        public static string appName = "Battlelog Browser";
        public static string homeUrl = "https://battlelog.battlefield.com/";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            // Upgrade Application Settings if applicable
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(new CefSettings { CachePath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "cache") });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BrowserForm());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
