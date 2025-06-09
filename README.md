# Lunaris Framework

## Summary

Lunaris is a C# framework designed to simplify and validate modern .NET applications by providing:

### Declarative Dependency Injection
- Uses `[Service]`, `[Setting]`, and `[DependsOn]` attributes
- Simplifies DI registration through source generators
- Eliminates boilerplate and improves test isolation
- Validates lifetime scopes and resolution correctness at compile time

### Message Handling Orchestration
- Supports `[Command]`, `[Message]`, `[Notification]`, and more
- Does not dispatch messages itself—works with MediatR, MassTransit, etc.
- Focuses on discovering, wiring, and validating message handlers
- Handlers can be declared using interfaces (e.g. `ICommandHandler<T>`) or attributes with method conventions (e.g. `Handle(FooCommand)`)

### Analyzer-Driven Validation
- Ensures messages have handlers
- Detects missing or duplicate consumers
- Catches invalid DI setups or unresolved dependencies
- Highlights architectural mismatches early in IDE or CI

### Pipeline & Extensibility
- Supports optional `IMessagePipeline` for metrics, retries, auth, etc.
- Declarative hooks for observability and behavior filters
- Custom attributes and pluggable resolution are first-class

### Framework-Agnostic Philosophy
Designed to integrate, not replace your existing tools:
- MediatR
- MassTransit
- Custom internal buses

Dispatch strategy is your choice—Lunaris just connects the dots.

## Lunaris Core Mission
To act as the intelligent middle layer that connects your intent with the application structure—improving code hygiene, reducing friction, and empowering scalable patterns.


## Building

The framework is organised as several class libraries. To build all packages
run the following command from the repository root:

```bash
dotnet build src/Lunaris.Core/Lunaris.Core.csproj
dotnet build src/Lunaris.Runtime/Lunaris.Runtime.csproj
```

This will compile the core and runtime libraries and restore necessary
dependencies. Additional packages such as `Lunaris.Generation` or
`Lunaris.Analyzers` can be built in the same manner.
