using UniVerseFlyClient.Domain.Entities;
using UniVerseFlyClient.Domain.Ports;

namespace UniVerseFlyClient.Application.UseCases
{
    /// <summary>
    /// Manages application settings.
    /// </summary>
    public class SettingsManager
    {
        private readonly ISettingsRepository _settingsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsManager"/> class.
        /// </summary>
        /// <param name="settingsRepository">The settings repository to use for persistence.</param>
        public SettingsManager(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        /// <summary>
        /// Loads the current client settings.
        /// </summary>
        /// <returns>The current <see cref="ClientSettings"/>.</returns>
        public ClientSettings LoadSettings()
        {
            return _settingsRepository.Load();
        }

        /// <summary>
        /// Saves the provided client settings.
        /// </summary>
        /// <param name="settings">The settings to save.</param>
        public void SaveSettings(ClientSettings settings)
        {
            _settingsRepository.Save(settings);
        }
    }
}
