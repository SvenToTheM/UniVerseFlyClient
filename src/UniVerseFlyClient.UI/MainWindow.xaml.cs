using System;
using System.Windows;
using Microsoft.Web.WebView2.Core;
using UniVerseFlyClient.Application.UseCases;
using UniVerseFlyClient.Domain.Entities;

namespace UniVerseFlyClient.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ClientSettings _settings;
        private readonly LaunchConfiguration _launchConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="settings">The client settings to use.</param>
        /// <param name="launchConfig">The launch configuration service.</param>
        public MainWindow(ClientSettings settings, LaunchConfiguration launchConfig)
        {
            InitializeComponent();
            _settings = settings;
            _launchConfig = launchConfig;
            Loaded += MainWindow_Loaded;
            KeyDown += MainWindow_KeyDown;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await InitializeWebViewAsync();
        }

        /// <summary>
        /// Initializes the WebView2 environment and control.
        /// </summary>
        private async System.Threading.Tasks.Task InitializeWebViewAsync()
        {
            try
            {
                var settings = _settings;

                // Apply Window Settings
                Width = settings.WindowWidth;
                Height = settings.WindowHeight;
                switch (settings.Mode)
                {
                    case Domain.Entities.WindowMode.Fullscreen:
                        WindowState = WindowState.Maximized;
                        WindowStyle = WindowStyle.None;
                        ResizeMode = ResizeMode.NoResize;
                        if (Topmost == false) Topmost = true; // Optional: Force top
                        break;
                    case Domain.Entities.WindowMode.WindowedFullscreen:
                        WindowState = WindowState.Maximized;
                        WindowStyle = WindowStyle.None;
                        break;
                    case Domain.Entities.WindowMode.Windowed:
                    default:
                        WindowState = WindowState.Normal;
                        WindowStyle = WindowStyle.SingleBorderWindow;
                        break;
                }

                // Initialize WebView2 Environment
                var additionalArgs = _launchConfig.GetAdditionalBrowserArguments(settings);
                var envOptions = new CoreWebView2EnvironmentOptions(additionalBrowserArguments: additionalArgs);

                // Cache user data in a local folder
                var userDataFolder = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "WebView2Data");

                var env = await CoreWebView2Environment.CreateAsync(null, userDataFolder, envOptions);

                await MainWebView.EnsureCoreWebView2Async(env);

                // Disable browser accelerator keys so they bubble to WPF
                MainWebView.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;

                // Focus WebView to ensure keys are captured (optional but good practice)
                MainWebView.Focus();

                // Navigate
                MainWebView.Source = new Uri(settings.TargetUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize game client: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.F11)
            {
                ToggleFullscreen();
                e.Handled = true;
            }
        }

        /// <summary>
        /// Toggles the window between fullscreen and windowed mode.
        /// </summary>
        private void ToggleFullscreen()
        {
            if (WindowStyle == WindowStyle.None)
            {
                // Switch to Windowed
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.SingleBorderWindow;
                ResizeMode = ResizeMode.CanResize;
                Topmost = false;
            }
            else
            {
                // Switch to WindowedFullscreen (default preference)
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
                ResizeMode = ResizeMode.NoResize;
            }
        }
    }
}