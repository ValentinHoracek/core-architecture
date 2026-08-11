using ArchUnitNET.Fluent;
using ValentinHoracek.Core.Architecture.Internal;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Complexity-oriented design rules.
/// </summary>
public static partial class Design
{
    /// <summary>
    /// Public constructors must define a bounded dependency surface.
    /// </summary>
    public static readonly IArchRule PublicConstructorsMustHaveAtMostFiveParameters =
        MethodMembers()
            .That()
            .AreConstructors()
            .And()
            .ArePublic()
            .Should()
            .HaveLessThanOrEqualParameters(Lexicon.MaxConstructorParameters)
            .Because("to prevent constructor bloat and preserve cohesion");
}