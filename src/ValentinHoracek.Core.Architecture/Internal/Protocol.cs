using System.Collections.Generic;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Runtime protocol configuration for dependency gravity.
/// </summary>
public static class Protocol
{
    /// <summary>
    /// Ordered namespace flow from inner to outer layers.
    /// </summary>
    public static List<string> DependencyFlow { get; set; } =
    [
        "*.Domain",
        "*.Application",
        "*.Infrastructure",
        "*.Web",
    ];

}