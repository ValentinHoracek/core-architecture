using ArchUnitNET.Fluent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Integrity-oriented design rules.
/// </summary>
public static partial class Design
{
    /// <summary>
    /// Internal classes should be sealed to avoid accidental inheritance chains.
    /// </summary>
    public static readonly IArchRule InternalClassesMustBeSealed =
        Classes()
            .That()
            .AreInternal()
            .And()
            .AreNotAbstract()
            .Should()
            .BeSealed()
            .Because("to keep internal implementation boundaries explicit");
}