<p align="center">
  <img src="src/UniVerseFlyClient.UI/Assets/app_icon.png" width="512" height="512" alt="UniVerse Fly Client Icon">
</p>

# UniVerseFlyClient

> [!IMPORTANT]
> **Disclaimer:** This is an unofficial fan project. Flyff Universe is a trademark of Gala Lab / PlayWorks. This software is not affiliated with, maintained by, or endorsed by the official developers. Use at your own risk.

A high-performance, standalone client wrapper for **Flyff Universe**, built with **.NET 10 (WPF)** and **WebView2**.

## 🚀 Features

- **Performance Optimized**: Configured with specific WebView2 arguments to disable background throttling and enable high-performance modes.
- **Clean Architecture**: Built using **Hexagonal Architecture** (Ports & Adapters) to ensure maintainability and testability.
- **Customizable**: Settings for window size, window mode, and target URL (configurable via `settings.json`).
- **Modern Stack**: C#, WPF, WebView2.
- **Toggle Fullscreen**: Integrated hotkey support for seamless switching between modes.

## 🏗️ Architecture

The solution follows a strict separation of concerns:

- **UniVerseFlyClient.Domain**: Core entities and port interfaces. (No dependencies)
- **UniVerseFlyClient.Application**: Business logic and use cases. (Depends on Domain)
- **UniVerseFlyClient.Infrastructure**: Adapters for external concerns like File I/O. (Depends on Application & Domain)
- **UniVerseFlyClient.UI**: The WPF Presentation layer. (Depends on all layers via Composition Root)

## 🛠️ Getting Started

### Prerequisites

- .NET 10 SDK
- WebView2 Runtime (Edge)

### Build & Run

1. Clone the repository.
2. Build the solution:
   ```bash
   dotnet build
   ```
3. Run the UI project:
   ```bash
   dotnet run --project src/UniVerseFlyClient.UI/UniVerseFlyClient.UI.csproj
   ```

## ⚙️ Configuration

A `settings.json` file will be created in the application directory on first run. You can modify it to change:

- `WindowWidth` / `WindowHeight`
- `Mode` (`Windowed`, `Fullscreen`, `WindowedFullscreen`)
- `TargetUrl` (Default: `https://universe.flyff.com/play`)
- `DisableBackgroundThrottling`

### CLI Arguments

You can override the window mode via command line arguments:

- `--window windowed`: Start in windowed mode.
- `--window fullscreen`: Start in exclusive fullscreen mode.
- `--window windowed-fullscreen`: Start in borderless windowed fullscreen (Default).

Example:
```bash
UniVerseFlyClient.exe --window windowed
```

## 📦 Releases

Automated releases are created whenever a new tag (e.g., `v1.0.0`) is pushed to the repository. The release includes a pre-compiled standalone executable for Windows (win-x64).

## ⌨️ Hotkeys

- **F11**: Toggles between Fullscreen/Windowed-Fullscreen and Windowed mode.

## 🤝 Contribution

Contributions are welcome! Please ensure you follow the existing Hexagonal Architecture pattern.

## 📄 License

MIT License
