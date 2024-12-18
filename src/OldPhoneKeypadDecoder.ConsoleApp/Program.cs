using System;
using OldPhoneKeypadDecoder.Services;
using OldPhoneKeypadDecoder.Strategies;

// Create the key layout strategy
var keyLayoutStrategy = new OldPhoneKeyLayoutStrategy();

// Create the decoder service
var decoderService = new OldPhoneKeypadDecoderService(keyLayoutStrategy);

Console.WriteLine("Old Phone Keypad Decoder");
Console.WriteLine("Enter your key sequence (or 'exit' to quit):");

while (true)
{
    var input = Console.ReadLine();

    if (input is null || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
        break;

    try
    {
        var result = decoderService.Decode(input);
        Console.WriteLine($"Decoded text: {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    Console.WriteLine("\nEnter another sequence (or 'exit' to quit):");
}

Console.WriteLine("Goodbye!");
