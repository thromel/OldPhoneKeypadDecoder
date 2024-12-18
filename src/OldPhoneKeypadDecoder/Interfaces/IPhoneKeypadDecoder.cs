namespace OldPhoneKeypadDecoder.Interfaces;

/// <summary>
/// Defines the contract for decoding old phone keypad input sequences into text.
/// This interface represents the main decoder functionality for converting
/// number sequences (like "222" for "C") into their corresponding characters.
/// </summary>
public interface IPhoneKeypadDecoder
{
    /// <summary>
    /// Decodes a sequence of keypad presses into text.
    /// </summary>
    /// <param name="input">The input string containing the sequence of key presses.</param>
    /// <returns>The decoded text string. Returns empty string if input is null.</returns>
    /// <exception cref="ArgumentException">Thrown when the input contains invalid characters.</exception>
    string Decode(string? input);
}