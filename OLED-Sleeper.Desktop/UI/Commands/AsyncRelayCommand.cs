using System.Windows.Input;

namespace OLED_Sleeper.UI.Commands;

/// <summary>
/// An asynchronous implementation of <see cref="ICommand"/> for WPF, supporting async/await and disabling while executing.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="AsyncRelayCommand"/> class.
/// </remarks>
/// <param name="execute">The asynchronous action to execute.</param>
/// <param name="canExecute">Predicate to determine if the command can execute.</param>
public class AsyncRelayCommand(Func<Task> execute, Func<bool>? canExecute = null) : ICommand
{
    private readonly Func<Task> _execute = execute ?? throw new ArgumentNullException(nameof(execute));
    private readonly Func<bool>? _canExecute = canExecute;
    private bool _isExecuting;

    /// <inheritdoc />
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value; remove => CommandManager.RequerySuggested -= value;
    }

    /// <summary>
    /// Determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">Command parameter (not used).</param>
    /// <returns>True if the command can execute; otherwise, false.</returns>
    public bool CanExecute(object? parameter) => !_isExecuting && (_canExecute?.Invoke() ?? true);

    /// <summary>
    /// Executes the command asynchronously.
    /// </summary>
    /// <param name="parameter">Command parameter (not used).</param>
    public async void Execute(object? parameter)
    {
        _isExecuting = true;
        CommandManager.InvalidateRequerySuggested();
        try
        {
            await _execute();
        }
        finally
        {
            _isExecuting = false;
            CommandManager.InvalidateRequerySuggested();
        }
    }
}