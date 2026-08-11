using ArchUnitNET.Fluent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Central facade for all architectural governance policies in the Core Ecosystem.
/// Aggregates vocabulary, design, and topology rules into a unified policy.
/// </summary>
public static class CorePolicy
{
    /// <summary>
    /// Global architecture policy that combines vocabulary, design, and topology policies.
    /// </summary>
    public static readonly IArchRule Global =
        CombineRules(
            Vocabulary.All,
            Design.All,
            Topology.All())
        .Because("to provide one authoritative policy entry point for architectural governance");
}
