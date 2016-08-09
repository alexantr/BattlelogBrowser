using CefSharp;

namespace Alexantr.BattlelogBrowser.Handlers
{
    internal class MenuHandler : IContextMenuHandler
    {
        private const int ShowDevTools = 26501;
        private const int CloseDevTools = 26502;
        private const int GoHome = 26503;

        void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //To disable the menu then call clear
            // model.Clear();

            //Removing existing menu item
            //model.Remove(CefMenuCommand.ViewSource); // Remove "View Source" option
            model.Remove(CefMenuCommand.Print);

            //Add new custom menu items
            model.AddSeparator();
            model.AddItem(CefMenuCommand.Reload, "Reload");
            model.AddItem((CefMenuCommand)GoHome, "Go Home");
            model.AddItem((CefMenuCommand)ShowDevTools, "Show DevTools");
            //model.AddItem((CefMenuCommand)CloseDevTools, "Close DevTools");
        }

        bool IContextMenuHandler.OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            if ((int)commandId == GoHome)
            {
                browserControl.Load("http://battlelog.battlefield.com/");
            }
            if ((int)commandId == ShowDevTools)
            {
                browser.ShowDevTools();
            }
            if ((int)commandId == CloseDevTools)
            {
                browser.CloseDevTools();
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