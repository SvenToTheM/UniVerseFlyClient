using System;
using System.IO;
using Newtonsoft.Json;
using UniVerseFlyClient.Domain.Entities;
using UniVerseFlyClient.Domain.Ports;

namespace UniVerseFlyClient.Infrastructure.Adapters
{
    /// <summary>
    /// Implementation of ISettingsRepository using a local JSON file.
    /// </summary>
    public class FileSettingsRepository : ISettingsRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSettingsRepository"/> class.
        /// </summary>
        /// <param name="fileName">The name of the settings file (default: settings.json).</param>
        public FileSettingsRepository(string fileName = "settings.json")
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }

        /// <summary>
        /// Loads the settings from the JSON file. If the file does not exist or an error occurs, returns default settings.
        /// </summary>
        /// <returns>The loaded <see cref="ClientSettings"/>.</returns>
        public ClientSettings Load()
        {
            if (!File.Exists(_filePath))
            {
                return new ClientSettings();
            }

            try
            {
                var json = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<ClientSettings>(json) ?? new ClientSettings();
            }
            catch
            {
                // Fallback to default settings in case of error
                return new ClientSettings();
            }
        }

        /// <summary>
        /// Saves the specified settings to the JSON file.
        /// </summary>
        /// <param name="settings">The settings to save.</param>
        public void Save(ClientSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }
    }
}
