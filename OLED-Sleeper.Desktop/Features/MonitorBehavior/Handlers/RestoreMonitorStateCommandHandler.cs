using OLED_Sleeper.Core.Interfaces;
using OLED_Sleeper.Features.MonitorBehavior.Commands;
using OLED_Sleeper.Features.MonitorBlackout.Commands;
using OLED_Sleeper.Features.MonitorDimming.Commands;
using Serilog;

namespace OLED_Sleeper.Features.MonitorBehavior.Handlers;

/// <summary>
/// Handles the execution of the <see cref="RestoreMonitorStateCommand"/>.
/// Restores a monitor to its default state by hiding overlays and undimming.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="RestoreMonitorStateCommandHandler"/> class.
/// </remarks>
/// <param name="mediator">The mediator for dispatching further commands.</param>
public class RestoreMonitorStateCommandHandler(IMediator mediator) : ICommandHandler<RestoreMonitorStateCommand>
{
    private readonly IMediator _mediator = mediator;

    /// <summary>
    /// Handles the command to restore the monitor's state.
    /// </summary>
    /// <param name="command">The command containing the monitor's hardware ID.</param>
    public Task HandleAsync(RestoreMonitorStateCommand command)
    {
        Log.Information("Restoring state for monitor {HardwareId}.", command.HardwareId);
        _mediator.SendAsync(new HideBlackoutOverlayCommand { HardwareId = command.HardwareId });
        _mediator.SendAsync(new ApplyUndimCommand { HardwareId = command.HardwareId });
        return Task.CompletedTask;
    }
}
