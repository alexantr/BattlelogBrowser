using Alexantr.BattlelogBrowser.Controls;
using Alexantr.BattlelogBrowser.Handlers;
using CefSharp;
using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace Alexantr.BattlelogBrowser
{
    public partial class BrowserForm : Form
    {
        private readonly ChromiumWebBrowser browser;

        private bool formStarted = false;

        public BrowserForm()
        {
            InitializeComponent();

            if (!Properties.Settings.Default.WindowLocation.IsEmpty)
                Location = Properties.Settings.Default.WindowLocation;

            if (!Properties.Settings.Default.WindowSize.IsEmpty)
                Size = Properties.Settings.Default.WindowSize;

            if (Properties.Settings.Default.Maximized)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;

            formStarted = true;

            browser = new ChromiumWebBrowser("http://battlelog.battlefield.com/")
            {
                Dock = DockStyle.Fill,
            };

            toolStripContainer.ContentPanel.Controls.Add(browser);

            browser.LifeSpanHandler = new LifeSpanHandler();

            //browser.LoadingStateChanged += OnLoadingStateChanged;
            //browser.ConsoleMessage += OnBrowserConsoleMessage;
            //browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            //browser.AddressChanged += OnBrowserAddressChanged;

            //var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            //var version = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}, Environment: {3}", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion, bitness);
            //DisplayOutput(version);
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => Text = args.Title);
        }

        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.WindowSize = Size;
                Properties.Settings.Default.WindowLocation = Location;
            }
            else
            {
                Properties.Settings.Default.WindowSize = RestoreBounds.Size;
                Properties.Settings.Default.WindowLocation = RestoreBounds.Location;
            }

            //if (WindowState == FormWindowState.Maximized)
            //    Properties.Settings.Default.Maximized = true;
            //else
            //    Properties.Settings.Default.Maximized = false;

            Properties.Settings.Default.Save();
        }

        private void BrowserForm_Resize(object sender, EventArgs e)
        {
            if (formStarted)
            {
                if (WindowState == FormWindowState.Maximized)
                    Properties.Settings.Default.Maximized = true;

                if (WindowState == FormWindowState.Normal)
                    Properties.Settings.Default.Maximized = false;
            }
        }
    }
}
