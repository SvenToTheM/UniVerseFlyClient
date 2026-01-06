using System;

namespace UniVerseFlyClient.Domain.Entities
{
    /// <summary>
    /// Represents the configuration settings for the Flyff Universe Client.
    /// </summary>
    public class ClientSettings
    {
        /// <summary>
        /// Gets or sets the width of the client window.
        /// </summary>
        public int WindowWidth { get; set; } = 1280;

        /// <summary>
        /// Gets or sets the height of the client window.
        /// </summary>
        public int WindowHeight { get; set; } = 720;

        /// <summary>
        /// Gets or sets the window mode (Windowed, Fullscreen, WindowedFullscreen).
        /// Default is WindowedFullscreen.
        /// </summary>
        public WindowMode Mode { get; set; } = WindowMode.WindowedFullscreen;

        /// <summary>
        /// Gets or sets the target URL for the WebView.
        /// </summary>
        public string TargetUrl { get; set; } = "https://universe.flyff.com/play";

        /// <summary>
        /// Gets or sets a value indicating whether background throttling should be disabled for better performance.
        /// </summary>
        public bool DisableBackgroundThrottling { get; set; } = true;
    }
}
