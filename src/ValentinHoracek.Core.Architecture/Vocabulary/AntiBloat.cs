using ArchUnitNET.Fluent;
using ValentinHoracek.Core.Architecture.Internal;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Anti-bloat naming rules.
/// </summary>
public static partial class Vocabulary
{
    /// <summary>
    /// Classes must not use broad or vague suffixes.
    /// </summary>
    public static readonly IArchRule ClassesMustNotUseProhibitedSuffixes =
        Types()
            .That()
            .AreClasses()
            .Should()
            .NotHaveName(Lexicon.ProhibitedSuffixes)
            .Because("broad suffixes often hide mixed responsibilities per Henney's Law");
}