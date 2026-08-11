using System.Collections.Generic;
using System.Linq;
using ArchUnitNET.Fluent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Layered topology rules based on dependency gravity.
/// </summary>
public static partial class Topology
{
    /// <summary>
    /// For each layer, disallow dependencies to any outer layer in the configured flow.
    /// </summary>
    public static IArchRule Layered => BuildLayeredGravityRule();

    private static IArchRule BuildLayeredGravityRule()
    {
        if (Protocol.DependencyFlow.Count < 2)
        {
            return Types()
                .That()
                .HaveName(".*")
                .Should()
                .Exist()
                .Because("the Gravity Protocol requires at least two layers in the dependency flow");
        }

        var rules = new List<IArchRule>();

        for (var i = 0; i < Protocol.DependencyFlow.Count - 1; i++)
        {
            var current = Protocol.DependencyFlow[i];
            var outers = Protocol.DependencyFlow.Skip(i + 1).ToArray();

            rules.Add(
                Types()
                    .That()
                    .ResideInNamespace(current, true)
                    .Should()
                    .NotDependOnAny(outers)
                    .Because("Violates the Gravity Protocol for the current Archetype"));
        }

        return CombineRules(rules.ToArray())
            .Because("Violates the Gravity Protocol for the current Archetype");
    }
}