# ValentinHoracek.Core.Architecture

Architectural guardrails and naming conventions for the Core Ecosystem.

## Overview

This package provides a comprehensive set of architectural governance rules built with **ArchUnitNET**. These rules enforce:

- **Vocabulary Rules**: contract, operation, state, and anti-bloat naming standards
- **Design Rules**: complexity, abstraction, integrity, and immutability constraints
- **Topology Rules**: layered boundary enforcement and dependency direction

## Usage

### Integrating Policies into xUnit Tests

To validate your codebase against the architectural policies, create architecture tests in your test project:

#### Global Policy (All Rules)

```csharp
using ArchUnitNET.Core;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using Xunit;
using ValentinHoracek.Core.Architecture;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace MyProject.Tests.Architecture;

public class ArchitectureTests
{
    private static readonly Architecture Architecture =
        new ArchLoader().LoadAssemblies(typeof(SomeTypeInMyProject).Assembly).Build();

    [Fact]
    public void GlobalPolicy_Should_BeEnforced()
    {
        CorePolicy.Global.Check(Architecture);
    }
}
```

#### Category-Specific Policies

```csharp
    [Fact]
    public void VocabularyPolicy_Should_BeEnforced()
    {
        Vocabulary.All.Check(Architecture);
    }

    [Fact]
    public void DesignPolicy_Should_BeEnforced()
    {
        Design.All.Check(Architecture);
    }

    [Fact]
    public void TopologyPolicy_Should_BeEnforced()
    {
        Topology.All.Check(Architecture);
    }
```

#### Individual Rules

```csharp
    [Fact]
    public void CustomRule_Should_BeEnforced()
    {
        // Use individual rules for targeted testing
        Vocabulary.InterfacesMustMatchContractPattern.Check(Architecture);
        Design.InternalClassesMustBeSealed.Check(Architecture);
    }
```

## Rule Categories

### Vocabulary Rules
- Interfaces follow contract naming and avoid implementation suffixes
- Boolean methods use predicate naming (`Is|Has|Can|Should|Contains|Any`)
- Async methods end with `Async`
- Value-returning, zero-arg accessors should avoid `Get*`
- Private/protected fields use `_camelCase`
- Public properties and constants use `PascalCase`
- Classes avoid prohibited bloat suffixes

### Design Rules
- Public constructors have ≤ 5 parameters
- Service/Repository constructors only accept interfaces
- Internal classes are sealed
- Domain classes are records
- Domain records avoid public setters

### Topology Rules
- Domain layer is independent of Infrastructure and Web layers

## Getting Started

1. Add the NuGet package to your test project
2. Reference `ValentinHoracek.Core.Architecture` in your test assembly
3. Load your target assemblies with `ArchLoader`
4. Execute `CorePolicy.Global.Check(architecture)` in an xUnit `[Fact]`

## License

MIT
