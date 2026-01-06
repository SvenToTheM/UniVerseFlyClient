using System.Windows;
using UniVerseFlyClient.Application.UseCases;
using UniVerseFlyClient.Infrastructure.Adapters;

namespace UniVerseFlyClient.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        /// <summary>
        /// Orchestrates the application startup and dependencies.
        /// </summary>
        /// <param name="e">The startup arguments.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Composition Root
            // 1. Infrastructure Layer
            var settingsRepository = new FileSettingsRepository();

            // 2. Application Layer
            var settingsManager = new SettingsManager(settingsRepository);
            var launchConfig = new LaunchConfiguration();
            var commandLineService = new CommandLineService();

            // Load and apply CLI overrides
            var currentSettings = settingsManager.LoadSettings();
            var updatedSettings = commandLineService.ParseArguments(e.Args, currentSettings);

            // Persist the settings (includes CLI overrides)
            settingsManager.SaveSettings(updatedSettings);

            // 3. UI Layer
            var mainWindow = new MainWindow(updatedSettings, launchConfig);
            mainWindow.Show();
        }
    }
}
