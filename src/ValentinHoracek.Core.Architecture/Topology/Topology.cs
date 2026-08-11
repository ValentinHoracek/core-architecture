using ArchUnitNET.Fluent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Topology rule set for boundary enforcement.
/// </summary>
public static partial class Topology
{
    /// <summary>
    /// Combined topology policy selected by the requested archetype.
    /// Defaults to no topology rules when no archetype is specified.
    /// </summary>
    public static IArchRule All(Archetype archetype = Archetype.None) =>
        archetype switch
        {
            Archetype.Layered => Layered,
            Archetype.VerticalSlice => VerticalSlice,
            Archetype.Library => Library,
            Archetype.WebApi => Layered,
            Archetype.None => NoTopology,
            _ => NoTopology,
        };

    private static IArchRule NoTopology =>
        Types()
            .That()
            .HaveName("a^")
            .Should()
            .NotExist()
            .Because("No topology archetype was specified, so topology rules are disabled");
}