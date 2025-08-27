# UML Diagrams for Media Player Adapter Pattern

This directory contains UML diagrams for the Media Player Adapter Pattern implementation in .NET 8.

## Files Generated

### PlantUML Source Files (.puml)
- `UML_ClassDiagram.puml` - Class diagram source
- `UML_SequenceDiagram.puml` - Sequence diagram source  
- `UML_AdapterPattern.puml` - Adapter pattern structure source

### Generated PNG Images
- `UML_ClassDiagram.png` - Complete system class diagram
- `UML_SequenceDiagram.png` - Method execution flow diagram
- `UML_AdapterPattern.png` - Adapter pattern structure diagram

### Utilities
- `Generate-UML-PNG.ps1` - PowerShell script to generate PNG files from PlantUML
- `UML_Diagrams_Viewer.html` - HTML viewer for all diagrams

## How to Regenerate PNG Files

### Method 1: Using PowerShell Script
```powershell
powershell -ExecutionPolicy Bypass -File "Generate-UML-PNG.ps1"
```

### Method 2: Using Online PlantUML Editor
1. Visit [plantuml.com](http://www.plantuml.com/plantuml/)
2. Copy content from any `.puml` file
3. Paste into the editor
4. Download as PNG

### Method 3: Using VS Code Extension
1. Install "PlantUML" extension in VS Code
2. Open any `.puml` file
3. Press `Ctrl+Shift+P`
4. Type "PlantUML: Export Current Diagram"
5. Select PNG format

## Diagram Descriptions

### Class Diagram
Shows the complete architecture including:
- `IMediaPlayer` interface (Target)
- `MediaPlayerAdapter` class (Adapter)
- `LegacyMediaPlayer` class (Adaptee)
- `MediaPlayerTests` test class
- `TestLegacyMediaPlayer` test helper class

### Sequence Diagram
Illustrates the flow when calling `adapter.Play("song.mp3")`:
1. Parameter validation
2. Delegation to legacy player
3. Console output
4. Return to client

### Adapter Pattern Structure
Classic Gang of Four Adapter pattern showing:
- Target interface
- Adapter implementation
- Adaptee (legacy system)
- Client usage

## Technical Details
- **Framework:** .NET 8
- **Language:** C# 12.0
- **Pattern:** Adapter Design Pattern
- **Testing:** MSTest Framework
- **Diagram Tool:** PlantUML