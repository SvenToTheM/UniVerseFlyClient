using UniVerseFlyClient.Domain.Entities;

namespace UniVerseFlyClient.Domain.Ports
{
    /// <summary>
    /// Defines the contract for persisting and retrieving client settings.
    /// </summary>
    public interface ISettingsRepository
    {
        /// <summary>
        /// Loads the client settings.
        /// </summary>
        /// <returns>The loaded <see cref="ClientSettings"/>.</returns>
        ClientSettings Load();

        /// <summary>
        /// Saves the specified client settings.
        /// </summary>
        /// <param name="settings">The settings to save.</param>
        void Save(ClientSettings settings);
    }
}
