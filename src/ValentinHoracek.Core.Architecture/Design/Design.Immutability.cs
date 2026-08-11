using ArchUnitNET.Fluent;
using ValentinHoracek.Core.Architecture.Internal;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Immutability-oriented design rules.
/// </summary>
public static partial class Design
{
    /// <summary>
    /// Domain classes must be modelled as records.
    /// </summary>
    public static readonly IArchRule DomainClassesMustBeRecords =
        Types()
            .That()
            .ResideInNamespace(Lexicon.DomainNamespace, true)
            .And()
            .AreClasses()
            .Should()
            .BeRecords()
            .Because("to ensure domain models default to value semantics and immutability");

    /// <summary>
    /// Domain records must not expose public setters.
    /// </summary>
    public static readonly IArchRule DomainRecordsMustNotExposePublicSetters =
        PropertyMembers()
            .That()
            .AreDeclaredInType(Lexicon.DomainNamespace)
            .And()
            .HavePublicSetter()
            .Should()
            .NotExist()
            .Because("to ensure immutability in domain records");
}