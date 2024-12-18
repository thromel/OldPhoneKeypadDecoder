# OldPhoneKeypadDecoder Source Code Documentation

## Architecture Overview

The OldPhoneKeypadDecoder library implements a classic phone keypad text input system using the Chain of Responsibility and Strategy patterns. The project is structured into two main components:

### Core Library (OldPhoneKeypadDecoder)

#### Key Components

1. **Services**
   - `OldPhoneKeypadDecoderService`: Main service implementing `IPhoneKeypadDecoder`
   - Manages the decoding process and orchestrates the handler chain

2. **Handlers (Chain of Responsibility)**
   - Base Handler: Abstract implementation of `ICharacterHandler`
   - Specialized Handlers:
     - `HashHandler`: Processes end-of-input (#)
     - `BackspaceHandler`: Handles deletion (*)
     - `SpaceHandler`: Manages spaces (0)
     - `DigitHandler`: Processes numeric inputs (2-9)
     - `DefaultHandler`: Catches unhandled characters

3. **Strategies**
   - `OldPhoneKeyLayoutStrategy`: Implements classic phone keypad mapping
   - Configurable through `IKeyLayoutStrategy` interface

4. **Models**
   - `DecodeContext`: Maintains state during decoding process
   - Manages character buffering and result building

### Console Application (OldPhoneKeypadDecoder.ConsoleApp)

- Simple console interface for testing the decoder
- Demonstrates basic usage of the library

## Design Patterns

1. **Chain of Responsibility**
   - Decouples input processing into specialized handlers
   - Allows flexible addition of new input handling rules
   - Each handler focuses on specific character types

2. **Strategy Pattern**
   - Encapsulates keyboard layout mapping
   - Allows different keyboard layouts to be implemented
   - Facilitates easy testing and modification of character mappings

## Dependencies

- .NET 8.0
- No external package dependencies for core library