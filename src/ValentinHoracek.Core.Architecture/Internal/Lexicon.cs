namespace ValentinHoracek.Core.Architecture.Internal;

/// <summary>
/// Central regex lexicon for architecture naming rules.
/// </summary>
internal static class Lexicon
{
    internal const string PascalCase = "^[A-Z][a-zA-Z0-9]*$";
    internal const string PrivateField = "^_[a-z][a-zA-Z0-9]*$";
    internal const string Interface = "^I[A-Z][a-zA-Z0-9]*$";
    internal const string BooleanPredicate = "^(Is|Has|Can|Should|Contains|Any).*";
    internal const string ProhibitedSuffixes = ".*(Manager|Helper|Utility|Util|Data|Info|Base|Impl|Definition|Def|Error)$";

    internal const string InterfaceProhibitedSuffixes = ".*(Impl|Definition|Def)$";
    internal const string ExceptionContainsError = ".*Error.*";
    internal const string AsyncSuffix = ".*Async$";
    internal const string NotGetPrefix = "^(?!Get).+";
    internal const string TaskReturn = "System.Threading.Tasks.Task*";
    internal const string ValueTaskReturn = "System.Threading.Tasks.ValueTask*";
    internal const string DomainNamespace = "*.Domain.*";
    internal const string DomainNamespaceLoose = "*.Domain*";
    internal const string InfrastructureNamespace = "*.Infrastructure*";
    internal const string WebNamespace = "*.Web*";
    internal const int MaxConstructorParameters = 5;
}