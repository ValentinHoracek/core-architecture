using ArchUnitNET.Fluent;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Abstraction-oriented design rules.
/// </summary>
public static partial class Design
{
    /// <summary>
    /// Public constructors for Service and Repository classes should depend on abstractions.
    /// </summary>
    public static readonly IArchRule ServiceAndRepositoryConstructorsMustUseInterfaces =
        MethodMembers()
            .That()
            .AreConstructors()
            .And()
            .ArePublic()
            .And()
            .AreDeclaredInType("*Service")
            .Or()
            .AreDeclaredInType("*Repository")
            .Should()
            .HaveParameterTypes(
                typeof(System.Collections.Generic.IEnumerable<>),
                typeof(System.Collections.Generic.ICollection<>),
                typeof(System.Collections.IEnumerable),
                typeof(System.Collections.ICollection),
                "System.*")
            .Because("to enforce dependency inversion and testability");
}