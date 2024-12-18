# OldPhoneKeypadDecoder Test Documentation

## Test Architecture

The test project implements comprehensive unit tests for the OldPhoneKeypadDecoder library using NUnit framework.

### Test Structure

1. **Service Tests**
   - Comprehensive testing of `OldPhoneKeypadDecoderService`
   - Covers all key input scenarios

### Test Categories

1. **Basic Input Processing**
   - Single character inputs
   - Multiple character sequences
   - Special character handling

2. **Edge Cases**
   - Empty input
   - Null input
   - Invalid sequences

3. **Complex Scenarios**
   - Multi-word inputs
   - Backspace operations
   - Mixed character types

## Test Dependencies

- NUnit (3.14.0)
- NUnit3TestAdapter (4.5.0)
- Microsoft.NET.Test.Sdk (17.8.0)
- coverlet.collector (6.0.0)

## Code Coverage

The project uses Codecov for tracking test coverage, integrated through GitHub Actions CI/CD pipeline.

## Running Tests
```bash
dotnet test
```

For coverage report:
```bash
dotnet test --collect:"XPlat Code Coverage"
```