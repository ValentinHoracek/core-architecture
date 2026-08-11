using ArchUnitNET.Fluent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Vertical-slice topology rules for feature isolation.
/// </summary>
public static partial class Topology
{
    /// <summary>
    /// Feature slices must not depend on each other.
    /// </summary>
    public static IArchRule VerticalSlice =>
        Slices()
            .Matching("*.Features.(*)")
            .Should()
            .NotDependOnEachOther()
            .Because("Violates the Isolation Protocol for the current Archetype");
}