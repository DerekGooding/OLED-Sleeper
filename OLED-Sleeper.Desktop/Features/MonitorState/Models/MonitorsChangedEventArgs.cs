using OLED_Sleeper.Features.MonitorInformation.Model;

namespace OLED_Sleeper.Features.MonitorState.Models;

/// <summary>
/// Provides data for monitor set change events, containing both the previous and current monitor lists.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="MonitorsChangedEventArgs"/> class.
/// </remarks>
/// <param name="oldMonitors">The list of monitors before the change.</param>
/// <param name="newMonitors">The list of monitors after the change.</param>
public class MonitorsChangedEventArgs(IReadOnlyList<MonitorInfo> oldMonitors, IReadOnlyList<MonitorInfo> newMonitors) : EventArgs
{
    /// <summary>
    /// Gets the list of monitors before the change occurred.
    /// </summary>
    public IReadOnlyList<MonitorInfo> OldMonitors { get; } = oldMonitors;

    /// <summary>
    /// Gets the list of monitors after the change occurred.
    /// </summary>
    public IReadOnlyList<MonitorInfo> NewMonitors { get; } = newMonitors;
}