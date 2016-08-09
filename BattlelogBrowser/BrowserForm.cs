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

        private string homeUrl = "http://battlelog.battlefield.com/";

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

            // get saved url
            string url = Properties.Settings.Default.CurrentUrl;
            if (string.IsNullOrWhiteSpace(url) || !Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                url = homeUrl;
            }

            browser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill,
            };

            Controls.Add(browser);

            browser.LifeSpanHandler = new LifeSpanHandler();
            browser.MenuHandler = new MenuHandler();

            //browser.LoadingStateChanged += OnLoadingStateChanged;
            //browser.ConsoleMessage += OnBrowserConsoleMessage;
            //browser.StatusMessage += OnBrowserStatusMessage;
            browser.TitleChanged += OnBrowserTitleChanged;
            browser.AddressChanged += OnBrowserAddressChanged;

            //var bitness = Environment.Is64BitProcess ? "x64" : "x86";
            //var version = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}, Environment: {3}", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion, bitness);
            //DisplayOutput(version);
        }

        /*private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            DisplayOutput(string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message));
        }*/

        /*private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => statusLabel.Text = args.Value);
        }*/

        /*private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            SetCanGoBack(args.CanGoBack);
            SetCanGoForward(args.CanGoForward);

            this.InvokeOnUiThreadIfRequired(() => SetIsLoading(!args.CanReload));
        }*/

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => Text = args.Title);
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs args)
        {
            Properties.Settings.Default.CurrentUrl = args.Address;
            //this.InvokeOnUiThreadIfRequired(() => urlTextBox.Text = args.Address);
        }

        /*private void SetCanGoBack(bool canGoBack)
        {
            this.InvokeOnUiThreadIfRequired(() => backButton.Enabled = canGoBack);
        }*/

        /*private void SetCanGoForward(bool canGoForward)
        {
            this.InvokeOnUiThreadIfRequired(() => forwardButton.Enabled = canGoForward);
        }*/

        /*private void SetIsLoading(bool isLoading)
        {
            //goButton.Text = isLoading ? "Stop" : "Go";
            //goButton.Image = isLoading ? Properties.Resources.stop : Properties.Resources.go;

            HandleToolStripLayout();
        }*/

        /*private void HandleToolStripLayout(object sender, LayoutEventArgs e)
        {
            HandleToolStripLayout();
        }*/

        /*private void HandleToolStripLayout()
        {
            var width = toolStrip.Width;
            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item != urlTextBox)
                {
                    width -= item.Width - item.Margin.Horizontal;
                }
            }
            urlTextBox.Width = Math.Max(0, width - urlTextBox.Margin.Horizontal - 18);
        }*/

        /*private void GoButton_Click(object sender, EventArgs e)
        {
            LoadUrl(urlTextBox.Text);
        }*/

        /*private void BackButton_Click(object sender, EventArgs e)
        {
            browser.Back();
        }*/

        /*private void ForwardButton_Click(object sender, EventArgs e)
        {
            browser.Forward();
        }*/

        /*private void UrlTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            LoadUrl(urlTextBox.Text);
        }*/

        /*private void LoadUrl(string url)
        {
            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                browser.Load(url);
            }
        }*/

        /*private void goHomeButton_Click(object sender, EventArgs e)
        {
            LoadUrl(homeUrl);
        }*/

        /*private void aboutButton_Click(object sender, EventArgs e)
        {
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            string appVersion = ver.Major + "." + ver.Minor + "." + ver.Revision;

            var bits = Environment.Is64BitProcess ? "x64" : "x86";
            var about = string.Format("Battlelog Browser {3} ({4})\n\nChromium: {0}\nCEF: {1}\nCefSharp: {2}", Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion, appVersion, bits);
            MessageBox.Show(about, "About Battlelog Browser", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }*/

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
