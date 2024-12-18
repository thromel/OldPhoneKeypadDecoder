# OldPhoneKeypadDecoder

A .NET library that converts numeric keypad sequences into text, simulating classic mobile phone text input (T9). Implements the Chain of Responsibility pattern for processing multi-press character sequences, special characters, backspace, and spaces.

[![.NET CI/CD](https://github.com/yourusername/OldPhoneKeypadDecoder/actions/workflows/ci-cd.yml/badge.svg)](https://github.com/yourusername/OldPhoneKeypadDecoder/actions/workflows/ci-cd.yml)
[![codecov](https://codecov.io/gh/yourusername/OldPhoneKeypadDecoder/branch/main/graph/badge.svg)](https://codecov.io/gh/yourusername/OldPhoneKeypadDecoder)

## Features

- Multi-press character selection (e.g., pressing '2' three times gives 'C')
- Special characters through the '1' key
- Backspace (*) and confirmation (#) functionality
- Space character through '0' key
- Pause between characters using space
- Chain of Responsibility pattern for extensible character handling

## Installation
```bash
dotnet add package OldPhoneKeypadDecoder
```

```csharp
using OldPhoneKeypadDecoder.Services;
using OldPhoneKeypadDecoder.Strategies;
// Create the decoder service
var keyLayoutStrategy = new OldPhoneKeyLayoutStrategy();
var decoderService = new OldPhoneKeypadDecoderService(keyLayoutStrategy);
// Decode input
string result = decoderService.Decode("44433555555666#"); // Returns "HELLO"
```
## Input Format

- Numbers (2-9): Letters (press multiple times for different letters)
- 1: Special characters (&, ', ()
- 0: Space character
- *: Backspace
- #: Confirm/End input
- Space: Pause between characters

### Key Mappings

- 1 -> &, ', (
- 2 -> A, B, C
- 3 -> D, E, F
- 4 -> G, H, I
- 5 -> J, K, L
- 6 -> M, N, O
- 7 -> P, Q, R, S
- 8 -> T, U, V
- 9 -> W, X, Y, Z
- 0 -> Space

## Examples
```csharp
decoderService.Decode("2#") // "A"
decoderService.Decode("22#") // "B"
decoderService.Decode("222#") // "C"
decoderService.Decode("44 444#") // "HI"
decoderService.Decode("44433 555#") // "IE"
decoderService.Decode("227#") // "B" (backspace removes 'A')
```
## Project Structure

- `src/OldPhoneKeypadDecoder/`: Core library
- `src/OldPhoneKeypadDecoder.ConsoleApp/`: Console application demo
- `tests/OldPhoneKeypadDecoder.Tests/`: Unit tests

## Documentation

- [Source Code Documentation](src/README.md): Detailed architecture overview, design patterns, and component descriptions
- [Testing Documentation](tests/README.md): Detailed testing overview


## Development
```bash
# Clone the repository
git clone https://github.com/thromel/OldPhoneKeypadDecoder.git
# Build the solution
dotnet build
# Run tests
dotnet test
# Run console demo
dotnet run --project src/OldPhoneKeypadDecoder.ConsoleApp
```

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.