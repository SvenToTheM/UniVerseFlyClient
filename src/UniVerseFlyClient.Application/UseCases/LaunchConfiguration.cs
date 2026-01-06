using System.Text;
using UniVerseFlyClient.Domain.Entities;

namespace UniVerseFlyClient.Application.UseCases
{
    /// <summary>
    /// Prepares the configuration and arguments for launching the WebView2 environment.
    /// </summary>
    public class LaunchConfiguration
    {
        /// <summary>
        /// Generates a string of command-line arguments for the browser process based on the specified settings.
        /// </summary>
        /// <param name="settings">The client settings used to determine which arguments to include.</param>
        /// <returns>A space-separated string of browser command-line arguments.</returns>
        public string GetAdditionalBrowserArguments(ClientSettings settings)
        {
            var sb = new StringBuilder();

            // High DPI support
            sb.Append("--high-dpi-support=1 ");
            sb.Append("--force-device-scale-factor=1 ");

            // User Agent Spoofing for reCAPTCHA/Google Login
            sb.Append("--user-agent=\"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36\" ");

            if (settings.DisableBackgroundThrottling)
            {
                // Prevent performance drops when window is not focused
                sb.Append("--disable-background-timer-throttling ");
                sb.Append("--disable-backgrounding-occluded-windows ");
                sb.Append("--disable-renderer-backgrounding ");
            }

            return sb.ToString().Trim();
        }
    }
}
