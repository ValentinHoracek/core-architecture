using ArchUnitNET.Fluent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Vocabulary rule set for naming and semantic consistency.
/// </summary>
public static partial class Vocabulary
{
    /// <summary>
    /// Combined vocabulary policy for contracts, operations, state, and anti-bloat constraints.
    /// </summary>
    public static readonly IArchRule All =
        CombineRules(
            InterfacesMustMatchContractPattern,
            InterfacesMustNotUseImplementationSuffixes,
            ExceptionsMustNotIncludeErrorInName,
            BooleanReturningMethodsMustBePredicates,
            AsyncMethodsMustEndWithAsync,
            AccessorsMustNotStartWithGet,
            FieldsMustUsePrivateFieldConvention,
            PublicPropertiesMustBePascalCase,
            ConstantsMustBePascalCase,
            ClassesMustNotUseProhibitedSuffixes)
        .Because("to keep ubiquitous language consistent and intention-revealing");
}