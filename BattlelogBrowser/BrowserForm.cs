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

            // restore window size and position
            if (!Properties.Settings.Default.WindowLocation.IsEmpty)
            {
                Location = Properties.Settings.Default.WindowLocation;
            }
            if (!Properties.Settings.Default.WindowSize.IsEmpty)
            {
                Size = Properties.Settings.Default.WindowSize;
            }
            if (Properties.Settings.Default.Maximized)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }

            formStarted = true;

            browser = new ChromiumWebBrowser(Program.homeUrl)
            {
                Dock = DockStyle.Fill,
            };

            Controls.Add(browser);

            browser.DownloadHandler = new DownloadHandler();
            browser.LifeSpanHandler = new LifeSpanHandler();
            browser.MenuHandler = new MenuHandler();

            browser.TitleChanged += OnBrowserTitleChanged;
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

            Properties.Settings.Default.Save();

            browser.Dispose();
            Cef.Shutdown();
        }

        private void BrowserForm_Resize(object sender, EventArgs e)
        {
            if (formStarted)
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    Properties.Settings.Default.Maximized = true;
                }

                if (WindowState == FormWindowState.Normal)
                {
                    Properties.Settings.Default.Maximized = false;
                }
            }
        }
    }
}
