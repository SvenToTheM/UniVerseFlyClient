using System;
using UniVerseFlyClient.Domain.Entities;

namespace UniVerseFlyClient.Application.UseCases
{
    /// <summary>
    /// Parses command line arguments to override client settings.
    /// </summary>
    public class CommandLineService
    {
        /// <summary>
        /// Parses the command line arguments and applies overrides to the provided settings.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        /// <param name="currentSettings">The settings to apply overrides to.</param>
        /// <returns>The updated settings.</returns>
        public ClientSettings ParseArguments(string[] args, ClientSettings currentSettings)
        {
            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i].ToLowerInvariant();

                if (arg == "--window" && i + 1 < args.Length)
                {
                    var modeStr = args[i + 1].ToLowerInvariant();
                    switch (modeStr)
                    {
                        case "windowed":
                            currentSettings.Mode = WindowMode.Windowed;
                            break;
                        case "fullscreen":
                            currentSettings.Mode = WindowMode.Fullscreen;
                            break;
                        case "windowed-fullscreen":
                            currentSettings.Mode = WindowMode.WindowedFullscreen;
                            break;
                    }
                    i++; // Skip next arg
                }
            }

            return currentSettings;
        }
    }
}
