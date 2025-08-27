# Media Player Adapter Pattern Demo

## Overview

Software design patterns are programming paradigms that describe reusable patterns for common design problems. They are a set of tried and tested solutions to common problems in software design. They are not algorithms or code snippets that can be copied and pasted into your code. They are more like templates that can be applied to different situations. They are not a substitute for good software design principles, but they are a good starting point for designing your software. They are a good way to document your design decisions and communicate your design to other developers.

**Adapter design pattern** is demonstrated in this project. The Adapter pattern is a structural design pattern that allows objects with incompatible interfaces to collaborate. It acts as a bridge between two incompatible interfaces by wrapping an existing class with a new interface. The Adapter pattern is particularly useful when you need to use an existing class, but its interface doesn't match what you need.

This project demonstrates the **Adapter Design Pattern** in C# (.NET 8), allowing a legacy media player with a different interface to work seamlessly with a new standardized `IMediaPlayer` interface.

## Design

This project defines a media player adapter system. The adapter is initialized with a legacy media player that has an incompatible interface. In real world scenarios, you may think of it as integrating various media players (Windows Media Player, VLC, etc.) under a common interface. In this case, it demonstrates how to adapt a legacy player's `PlayFile` method to work with a modern `IMediaPlayer` interface. As the adapter delegates calls to the legacy player, it translates the interface calls seamlessly; thus demonstrating the adapter pattern.

## UML Diagram
![uml_diagram](/UML_diagram.png)

## Environment

The project builds and runs with:
- **.NET 8.0** - Latest .NET runtime
- **Visual Studio 2022** or **Visual Studio Code** with C# extension
- **Command Line Interface** - Compatible with dotnet CLI




