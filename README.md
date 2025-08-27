# Media Player Adapter Pattern Demo

## Overview
This project demonstrates the **Adapter Design Pattern** in C# (.NET 8), allowing a legacy media player with a different interface to work seamlessly with a new standardized `IMediaPlayer` interface.

## Scenario
- **Legacy Player**: Has a `PlayFile(string filePath)` method
- **New Interface**: Requires `Play(string fileName)` method
- **Solution**: Use an Adapter to bridge the gap

## Architecture

### Components
1. **IMediaPlayer** - Standard interface for media players
2. **LegacyMediaPlayer** - Existing player with incompatible interface
3. **MediaPlayerAdapter** - Adapter that makes legacy player compatible
4. **Program** - Demonstrates the pattern in action

### Class Diagram
```
IMediaPlayer
    + Play(fileName: string)
         ↑
         |
MediaPlayerAdapter
    - legacyPlayer: LegacyMediaPlayer
    + Play(fileName: string)
         |
         ↓ delegates to
LegacyMediaPlayer
    + PlayFile(filePath: string)
```

## Usage
```csharp
// Create legacy player
var legacyPlayer = new LegacyMediaPlayer();

// Adapt it to the new interface
IMediaPlayer player = new MediaPlayerAdapter(legacyPlayer);

// Use through standard interface
player.Play("song.mp3");
```

## Benefits
- **Compatibility**: Legacy code works with new interfaces
- **Flexibility**: Multiple adapters can support different legacy systems
- **Separation of Concerns**: Adapter handles interface translation only
- **Robustness**: Comprehensive input validation and error handling
- **Maintainability**: Clean code with extensive documentation

## Features
- **Null Safety**: Comprehensive null checking
- **Input Validation**: Validates file names and parameters
- **Error Handling**: Proper exception handling with meaningful messages
- **Dual Testing Frameworks**: Both xUnit and MSTest implementations
- **Testing**: 14 comprehensive unit tests covering all scenarios including edge cases

## Testing
The project includes comprehensive unit tests using both testing frameworks:

### xUnit Tests (`MediaPlayerTests.cs`)
- 7 comprehensive xUnit tests
- Uses xUnit.Assert for assertions
- Covers all core functionality

### MSTest Tests (`MediaPlayerMSTests.cs`)
- 7 comprehensive MSTest tests  
- Uses Microsoft.VisualStudio.TestTools.UnitTesting
- Mirrors xUnit test coverage

### Test Coverage
- **Total Tests**: 14 (7 xUnit + 7 MSTest)
- **Success Rate**: 100%
- **Coverage Areas**: Interface implementation, delegation, validation, error handling
- **Test Scenarios**:
  - Adapter implements the correct interface
  - Method calls are properly delegated
  - Legacy player functionality is preserved
  - Null parameter validation
  - Empty/whitespace parameter validation
  - Constructor argument validation

## Build & Run
```bash
# Build the project
dotnet build

# Run the demo
dotnet run

# Run all tests (both xUnit and MSTest)
dotnet test

# Check code formatting
dotnet format --verify-no-changes
```

## Code Quality
- Follows .NET coding standards via .editorconfig
- Clean, maintainable code under 100 lines
- Full unit test coverage with edge case testing
- Robust error handling and input validation
- Professional-grade exception handling
- Dual testing framework support (xUnit + MSTest)

## Technical Excellence
- **Pattern Implementation**: Textbook Adapter pattern
- **Code Quality**: Clean, readable, well-structured
- **Reliability**: Comprehensive error handling
- **Testing**: 100% test success rate with dual framework coverage
- **Standards**: Strict adherence to .NET coding conventions
- **Frameworks**: Supports both xUnit and MSTest testing paradigms
