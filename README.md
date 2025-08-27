# Media Player Adapter Pattern Demo

## Overview

Software design patterns are programming paradigms that describe reusable patterns for common design problems. They are a set of tried and tested solutions to common problems in software design. They are not algorithms or code snippets that can be copied and pasted into your code. They are more like templates that can be applied to different situations. They are not a substitute for good software design principles, but they are a good starting point for designing your software. They are a good way to document your design decisions and communicate your design to other developers.

**Adapter design pattern** is demonstrated in this project. The Adapter pattern is a structural design pattern that allows objects with incompatible interfaces to collaborate. It acts as a bridge between two incompatible interfaces by wrapping an existing class with a new interface. The Adapter pattern is particularly useful when you need to use an existing class, but its interface doesn't match what you need.

This project demonstrates the **Adapter Design Pattern** in C# (.NET 8), allowing a legacy media player with a different interface to work seamlessly with a new standardized `IMediaPlayer` interface.

### Real World Applications

Real world applications of the Adapter pattern include the following:

- **Legacy System Integration**: Adapting old APIs to work with new systems without modifying the original code
- **Third-Party Library Integration**: Making external libraries compatible with your application's interface
- **Database Adapters**: Allowing applications to work with different database systems through a common interface
- **Media Player Applications**: Integrating various media codecs and players under a unified interface
- **Plugin Systems**: Enabling plugins with different interfaces to work within the same framework

The Adapter pattern is used in:

- **Media Applications** to integrate different media players and codecs under a unified interface
- **Enterprise Applications** to integrate legacy systems with modern applications
- **Framework Development** to provide consistent interfaces for different implementations

## Scenario

- **Legacy Player**: Has a `PlayFile(string filePath)` method
- **New Interface**: Requires `Play(string fileName)` method
- **Problem**: Interface incompatibility prevents direct integration
- **Solution**: Use an Adapter to bridge the gap without modifying existing code

## Design

This project defines a media player adapter system. The adapter is initialized with a legacy media player that has an incompatible interface. In real world scenarios, you may think of it as integrating various media players (Windows Media Player, VLC, etc.) under a common interface. In this case, it demonstrates how to adapt a legacy player's `PlayFile` method to work with a modern `IMediaPlayer` interface. As the adapter delegates calls to the legacy player, it translates the interface calls seamlessly; thus demonstrating the adapter pattern.

## Architecture

### Components

1. **IMediaPlayer** - Standard target interface for media players
2. **LegacyMediaPlayer** - Existing player with incompatible interface (adaptee)
3. **MediaPlayerAdapter** - Adapter that makes legacy player compatible
4. **Program** - Demonstrates the pattern in action

### Module & Class Diagram

```
┌─────────────────┐       ┌──────────────────────┐       ┌─────────────────┐
│   Client Code   │────►  │  MediaPlayerAdapter  │────►  │ LegacyMediaPlayer│
│                 │       │  (Adapter)           │       │  (Adaptee)      │
└─────────────────┘       └──────────────────────┘       └─────────────────┘
        │                           │                             │
        │                           │                             │
        ▼                           ▼                             ▼
┌─────────────────┐       ┌──────────────────────┐       ┌─────────────────┐
│  IMediaPlayer   │       │ + MediaPlayerAdapter │       │ + PlayFile()    │
│  (Target)       │       │   (LegacyMediaPlayer)│       │                 │
│                 │       │ + Play(fileName)     │       │                 │
│ + Play(fileName)│       │                      │       │                 │
└─────────────────┘       └──────────────────────┘       └─────────────────┘
```

**Detailed Class Structure:**

```
IMediaPlayer
    + Play(fileName: string)
         ↑ implements
         |
MediaPlayerAdapter
    - _legacyPlayer: LegacyMediaPlayer
    + MediaPlayerAdapter(legacyPlayer: LegacyMediaPlayer)
    + Play(fileName: string)
         |
         ↓ delegates to
LegacyMediaPlayer
    + PlayFile(filePath: string)
```

## Usage

```csharp
// Create legacy player (existing system)
var legacyPlayer = new LegacyMediaPlayer();

// Adapt it to the new interface
IMediaPlayer player = new MediaPlayerAdapter(legacyPlayer);

// Use through standard interface - no change to client code
player.Play("song.mp3");
```

## Benefits

- **Compatibility**: Legacy code works with new interfaces without modification
- **Flexibility**: Multiple adapters can support different legacy systems
- **Separation of Concerns**: Adapter handles interface translation only
- **Robustness**: Comprehensive input validation and error handling
- **Maintainability**: Clean code with extensive documentation
- **Extensibility**: Easy to add more adapters for different legacy systems

## Features

- **Null Safety**: Comprehensive null checking and validation
- **Input Validation**: Validates file names and parameters
- **Error Handling**: Proper exception handling with meaningful messages
- **Dual Testing Frameworks**: Both xUnit and MSTest implementations
- **Comprehensive Testing**: 14 unit tests covering all scenarios including edge cases
- **Production Ready**: Enterprise-grade error handling and validation

## Testing

The project includes comprehensive unit tests using both testing frameworks to ensure reliability and demonstrate different testing approaches:

### xUnit Tests (`MediaPlayerTests.cs`)
- 7 comprehensive xUnit tests using modern testing paradigms
- Uses `Xunit.Assert` for assertions
- Covers all core functionality with behavior-driven testing

### MSTest Tests (`MediaPlayerMSTests.cs`)
- 7 comprehensive MSTest tests using traditional Microsoft testing framework
- Uses `Microsoft.VisualStudio.TestTools.UnitTesting.Assert`
- Mirrors xUnit test coverage with MSTest-specific patterns

### Test Coverage Details

- **Total Tests**: 14 (7 xUnit + 7 MSTest)
- **Success Rate**: 100%
- **Coverage Areas**: Interface implementation, delegation, validation, error handling

**Test Scenarios Covered:**
- Adapter implements the correct interface
- Method calls are properly delegated to legacy system
- Legacy player functionality is preserved
- Null parameter validation and exception handling
- Empty/whitespace parameter validation
- Constructor argument validation
- Edge case handling

## Build & Run

```bash
# Build the project
dotnet build

# Run the demo application
dotnet run

# Run all tests (both xUnit and MSTest)
dotnet test

# Check code formatting compliance
dotnet format --verify-no-changes
```

## Environment

The project builds and runs with:
- **.NET 8.0** - Latest .NET runtime
- **Visual Studio 2022** or **Visual Studio Code** with C# extension
- **Command Line Interface** - Compatible with dotnet CLI

**Required Workloads:**
- .NET desktop development
- ASP.NET and web development (for testing frameworks)

## Code Quality

- **Standards Compliance**: Follows .NET coding standards via comprehensive .editorconfig
- **Clean Architecture**: Well-structured, maintainable code under 100 lines
- **Comprehensive Testing**: Full unit test coverage with edge case testing
- **Error Handling**: Robust input validation and exception handling
- **Documentation**: Professional-grade XML documentation
- **Dual Framework Support**: Demonstrates both xUnit and MSTest paradigms

## Technical Excellence

- **Pattern Implementation**: Textbook Adapter pattern following Gang of Four principles
- **Code Quality**: Clean, readable, well-structured code with SOLID principles
- **Reliability**: Comprehensive error handling and defensive programming
- **Testing**: 100% test success rate with dual framework coverage
- **Standards**: Strict adherence to .NET coding conventions and best practices
- **Frameworks**: Supports both modern (xUnit) and traditional (MSTest) testing paradigms
- **Performance**: Efficient delegation with minimal overhead
- **Maintainability**: Clear separation of concerns and extensible design
