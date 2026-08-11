using ArchUnitNET.Fluent;
using ValentinHoracek.Core.Architecture.Internal;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Operation naming rules.
/// </summary>
public static partial class Vocabulary
{
    /// <summary>
    /// Methods returning bool must use predicate naming.
    /// </summary>
    public static readonly IArchRule BooleanReturningMethodsMustBePredicates =
        Methods()
            .That()
            .HaveReturnType(typeof(bool))
            .Should()
            .HaveName(Lexicon.BooleanPredicate)
            .Because("boolean methods should express intent as predicates");

    /// <summary>
    /// Methods returning Task or ValueTask must end with Async.
    /// </summary>
    public static readonly IArchRule AsyncMethodsMustEndWithAsync =
        Methods()
            .That()
            .ArePublic()
            .And()
            .HaveReturnType(Lexicon.TaskReturn)
            .Or()
            .HaveReturnType(Lexicon.ValueTaskReturn)
            .Should()
            .HaveName(Lexicon.AsyncSuffix)
            .Because("async workflows should be explicit at call sites");

    /// <summary>
    /// Zero-parameter value-returning accessors must not start with Get.
    /// Excludes runtime methods and virtual/override members.
    /// </summary>
    public static readonly IArchRule AccessorsMustNotStartWithGet =
        Methods()
            .That()
            .ArePublic()
            .And()
            .HaveNoParameters()
            .And()
            .DoNotHaveReturnType(typeof(void))
            .And()
            .DoNotHaveName("GetHashCode")
            .And()
            .DoNotHaveName("GetEnumerator")
            .And()
            .DoNotHaveName("GetType")
            .And()
            .AreNotVirtual()
            .Should()
            .HaveName(Lexicon.NotGetPrefix)
            .Because("accessors should communicate state, not retrieval mechanics");
}