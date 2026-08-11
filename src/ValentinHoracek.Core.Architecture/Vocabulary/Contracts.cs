using ArchUnitNET.Fluent;
using ValentinHoracek.Core.Architecture.Internal;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ValentinHoracek.Core.Architecture;

/// <summary>
/// Contract naming rules.
/// </summary>
public static partial class Vocabulary
{
    /// <summary>
    /// Interfaces must match the interface naming contract.
    /// </summary>
    public static readonly IArchRule InterfacesMustMatchContractPattern =
        Types()
            .That()
            .AreInterfaces()
            .Should()
            .HaveName(Lexicon.Interface)
            .Because("to ensure contracts are easily recognizable");

    /// <summary>
    /// Interfaces must not use implementation-oriented suffixes.
    /// </summary>
    public static readonly IArchRule InterfacesMustNotUseImplementationSuffixes =
        Types()
            .That()
            .AreInterfaces()
            .Should()
            .NotHaveName(Lexicon.InterfaceProhibitedSuffixes)
            .Because("to keep abstractions free from implementation leakage");

    /// <summary>
    /// Exception types must not include Error in their name.
    /// </summary>
    public static readonly IArchRule ExceptionsMustNotIncludeErrorInName =
        Types()
            .That()
            .Inherit("System.Exception")
            .Should()
            .NotHaveName(Lexicon.ExceptionContainsError)
            .Because("to keep exception naming precise and avoid generic error labels");
}