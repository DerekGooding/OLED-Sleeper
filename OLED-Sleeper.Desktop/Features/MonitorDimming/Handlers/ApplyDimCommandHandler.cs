using OLED_Sleeper.Core.Interfaces;
using OLED_Sleeper.Features.MonitorDimming.Commands;
using OLED_Sleeper.Features.MonitorDimming.Services.Interfaces;
using Serilog;

namespace OLED_Sleeper.Features.MonitorDimming.Handlers;

/// <summary>
/// Handles the execution of the <see cref="ApplyDimCommand"/>.
/// This class contains the business logic for dimming a monitor to a specified brightness level.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ApplyDimCommandHandler"/> class.
/// </remarks>
/// <param name="monitorDimmingService">The service responsible for controlling monitor brightness.</param>
public class ApplyDimCommandHandler(
    IMonitorDimmingService monitorDimmingService) : ICommandHandler<ApplyDimCommand>
{
    private readonly IMonitorDimmingService _monitorDimmingService = monitorDimmingService;

    /// <summary>
    /// Executes the dimming logic asynchronously based on the command's data.
    /// Exceptions are caught and logged to avoid silent failures.
    /// </summary>
    /// <param name="command">The command containing the details of the monitor to dim and the target brightness level.</param>
    public async Task HandleAsync(ApplyDimCommand command)
    {
        try
        {
            Log.Information("Executing ApplyDimCommand for monitor {HardwareId} to level {DimLevel}.", command.HardwareId, command.DimLevel);
            await _monitorDimmingService.DimMonitorAsync(command.HardwareId, command.DimLevel);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to dim monitor {HardwareId} to level {DimLevel}.", command.HardwareId, command.DimLevel);
        }
    }
}