# core-architecture — agent guide

.NET 10 NuGet package `ValentinHoracek.Core.Architecture` (version `0.1.0-alpha`, MIT).
It contains ArchUnitNET rules. Apps reference the package from their xUnit test projects and call the rules there.
There is no application code in this repo.

## Commands

Requires the .NET 10 SDK. Run from the repo root. Under WSL, use `dotnet.exe` (Windows SDK); `dotnet` is not installed in WSL.

- Build: `dotnet.exe build Core.slnx`
- Pack: `dotnet.exe pack Core.slnx -c Release`

## Code map

All paths are under `src/ValentinHoracek.Core.Architecture/`.

- `Rules.cs` — `CorePolicy.Global`: combines `Vocabulary.All`, `Design.All`, `Topology.All()`.
- `Vocabulary/` — naming rules (`public static partial class Vocabulary`). One file per rule group; `Vocabulary.cs` holds `All`.
- `Design/` — structural rules (`public static partial class Design`). One file per rule group; `Design.cs` holds `All`.
- `Topology/` — boundary rules (`public static partial class Topology`). `Topology.All(Archetype)` picks the rule set for an archetype; with `Archetype.None` no topology rule applies.
- `Internal/Lexicon.cs` — the preferred home for regex patterns and numeric limits. Existing exceptions with patterns written directly in the rule: `Design/Design.Abstractions.cs` (`*Service`, `*Repository`, `System.*`), `Topology/Library.cs`, `Topology/VerticalSlice.cs`, `Topology/Layered.cs`, `Topology/Topology.cs`.
- `Internal/Protocol.cs` — `Protocol.DependencyFlow`: layer order from inner to outer.
- `Internal/Archetype.cs` — `Archetype` enum: `None`, `Library`, `WebApi`, `VerticalSlice`, `Layered`.

## Adding a Vocabulary or Design rule

1. Put it in the matching category, in the file for its rule group (or a new `<Category>.<Group>.cs` / `<Group>.cs` file following the folder's existing naming).
2. Take regex patterns and limits from `Lexicon`. Add a new constant there if needed. Do not add new patterns directly in the rule.
3. Declare it as `public static readonly IArchRule <DescriptiveName>` with an XML doc comment and a `.Because("…")` reason.
4. Add it to the category's `All`.
5. Add it to the rule list in `src/ValentinHoracek.Core.Architecture/README.md`.

## Adding a Topology archetype

Topology rules are not combined. Each archetype has one rule set, and `Topology.All(Archetype)` picks one with a `switch`.

1. Add a value to the `Archetype` enum.
2. Add a `public static IArchRule <Name> =>` property in a new `Topology/<Name>.cs`, with an XML doc comment and a `.Because("…")` reason.
3. Map the new enum value to the property in the `Topology.All` switch.
4. Add it to the rule list in `src/ValentinHoracek.Core.Architecture/README.md`.

## Library conventions

- The library follows its own rules: internal classes are `sealed`, private fields use `_camelCase`, no `Manager`/`Helper`/`Util` suffixes.
- A change to the public API requires a `<Version>` bump in the `.csproj`.

## Known gaps

- No test project. Rules are not verified automatically.
