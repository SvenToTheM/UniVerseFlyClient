namespace UniVerseFlyClient.Domain.Entities
{
    /// <summary>
    /// Specifies the window display mode for the game client.
    /// </summary>
    public enum WindowMode
    {
        /// <summary>
        /// Standard windowed mode with borders and title bar.
        /// </summary>
        Windowed,

        /// <summary>
        /// Exclusive fullscreen mode.
        /// </summary>
        Fullscreen,

        /// <summary>
        /// Borderless windowed mode that covers the entire screen.
        /// </summary>
        WindowedFullscreen
    }
}
