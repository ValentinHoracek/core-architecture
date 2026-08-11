using ArchUnitNET.Fluent;
using ValentinHoracek.Core.Architecture.Internal;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// State and member naming rules.
/// </summary>
public static partial class Vocabulary
{
    /// <summary>
    /// Private and protected fields must use underscore-prefixed camelCase.
    /// </summary>
    public static readonly IArchRule FieldsMustUsePrivateFieldConvention =
        Fields()
            .That()
            .ArePrivate()
            .Or()
            .AreProtected()
            .Should()
            .HaveName(Lexicon.PrivateField)
            .Because("field visibility should follow a uniform convention");

    /// <summary>
    /// Public properties must use PascalCase.
    /// </summary>
    public static readonly IArchRule PublicPropertiesMustBePascalCase =
        PropertyMembers()
            .That()
            .ArePublic()
            .Should()
            .HaveName(Lexicon.PascalCase)
            .Because("public API surface should remain consistent and idiomatic");

    /// <summary>
    /// Constants should use PascalCase.
    /// </summary>
    public static readonly IArchRule ConstantsMustBePascalCase =
        Fields()
            .That()
            .AreStatic()
            .And()
            .AreReadOnly()
            .Should()
            .HaveName(Lexicon.PascalCase)
            .Because("constants should align with .NET naming guidelines");
}