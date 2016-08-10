using CefSharp;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Alexantr.BattlelogBrowser.Handlers
{
    internal class MenuHandler : IContextMenuHandler
    {
        private const int ShowDevTools = 26501;
        //private const int CloseDevTools = 26502;
        private const int GoHome = 26503;
        private const int ShowAbout = 26504;
        private const int ShowAddress = 26505;

        void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //To disable the menu then call clear
            //model.Clear();

            //Removing existing menu item
            model.Remove(CefMenuCommand.ViewSource); // Remove "View Source" option
            model.Remove(CefMenuCommand.Print);

            //Add new custom menu items
            model.AddItem(CefMenuCommand.Reload, "Reload");
            model.AddItem((CefMenuCommand)GoHome, "Go Home");
            model.AddItem((CefMenuCommand)ShowAddress, "Show current URL");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)ShowDevTools, "Developer tools");
            model.AddSeparator();
            model.AddItem((CefMenuCommand)ShowAbout, string.Format("About {0}", Program.appName));
        }

        bool IContextMenuHandler.OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            if ((int)commandId == ShowDevTools)
            {
                browser.ShowDevTools();
            }
            if ((int)commandId == GoHome)
            {
                browserControl.Load(Program.homeUrl);
            }
            if ((int)commandId == ShowAbout)
            {
                Version ver = Assembly.GetExecutingAssembly().GetName().Version;
                string appVersion = ver.Major + "." + ver.Minor + "." + ver.Revision;

                var bits = Environment.Is64BitProcess ? "x64" : "x86";
                var about = string.Format("{0} {4} ({5})\n\nChromium: {1}\nCEF: {2}\nCefSharp: {3}", Program.appName, Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion, appVersion, bits);
                MessageBox.Show(about, string.Format("About {0}", Program.appName), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if ((int)commandId == ShowAddress)
            {
                MessageBox.Show(browserControl.Address, "Current URL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return false;
        }

        void IContextMenuHandler.OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {

        }

        bool IContextMenuHandler.RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}