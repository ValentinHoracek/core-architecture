using ArchUnitNET.Fluent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Library topology rules for framework independence and inheritance control.
/// </summary>
public static partial class Topology
{
    /// <summary>
    /// Library archetype enforces ASP.NET independence and controlled inheritance.
    /// </summary>
    public static IArchRule Library =>
        CombineRules(
            Types()
                .Should()
                .NotDependOnAny("Microsoft.AspNetCore.*")
                .Because("Violates the Independence Protocol for the current Archetype"),
            Classes()
                .That()
                .AreNotAbstract()
                .Should()
                .BeSealed()
                .Because("Violates the Independence Protocol for the current Archetype"))
        .Because("Violates the Independence Protocol for the current Archetype");
}