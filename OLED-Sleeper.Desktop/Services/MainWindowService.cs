using OLED_Sleeper.Services.Interfaces;
using OLED_Sleeper.ViewModels;
using OLED_Sleeper.Views;

namespace OLED_Sleeper.Services;

/// <summary>
/// Provides methods to set up, show, and activate the main window.
/// </summary>
/// <remarks>
/// Initializes a new instance of <see cref="MainWindowService"/>.
/// </remarks>
/// <param name="mainWindow">The main application window.</param>
/// <param name="mainViewModel">The main view model for the window.</param>
public class MainWindowService(MainWindow mainWindow, MainViewModel mainViewModel) : IMainWindowService
{
    private readonly MainWindow _mainWindow = mainWindow;
    private readonly MainViewModel _mainViewModel = mainViewModel;

    /// <summary>
    /// Sets up the main window as the application's main window, assigns its data context, and shows it.
    /// </summary>
    public void SetupMainWindow()
    {
        Application.Current.MainWindow = _mainWindow;
        _mainWindow.DataContext = _mainViewModel;
        ShowMainWindow();
    }

    /// <summary>
    /// Brings the main window to the foreground and restores it if minimized.
    /// </summary>
    public void ShowMainWindow()
    {
        _mainWindow.Show();
        if (_mainWindow.WindowState == WindowState.Minimized)
        {
            _mainWindow.WindowState = WindowState.Normal;
        }
        _mainWindow.Activate();
    }
}