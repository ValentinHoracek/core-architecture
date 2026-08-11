using ArchUnitNET.Fluent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Design rule set for structural integrity.
/// </summary>
public static partial class Design
{
    /// <summary>
    /// Combined design policy for complexity, abstractions, integrity, and immutability.
    /// </summary>
    public static readonly IArchRule All =
        CombineRules(
            PublicConstructorsMustHaveAtMostFiveParameters,
            ServiceAndRepositoryConstructorsMustUseInterfaces,
            InternalClassesMustBeSealed,
            DomainClassesMustBeRecords,
            DomainRecordsMustNotExposePublicSetters)
        .Because("to keep designs simple, stable, and immutable by default");
}