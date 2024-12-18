using System.Collections.Generic;
using OldPhoneKeypadDecoder.Interfaces;

namespace OldPhoneKeypadDecoder.Strategies
{
    /// <summary>
    /// Implements the classic mobile phone keypad layout strategy where:
    /// - 2-9 map to letters (ABC, DEF, etc.)
    /// - 1 maps to special characters
    /// - 0 maps to space
    ///
    /// The strategy handles cycling through characters based on the number
    /// of key presses (e.g., pressing '2' once gives 'A', twice gives 'B', etc.)
    /// </summary>
    public class OldPhoneKeyLayoutStrategy : IKeyLayoutStrategy
    {
        private static readonly Dictionary<char, char[]> KeyMap = new Dictionary<char, char[]>
        {
            { '1', new[] { '&', '\'', '(' } },
            { '2', new[] { 'A', 'B', 'C' } },
            { '3', new[] { 'D', 'E', 'F' } },
            { '4', new[] { 'G', 'H', 'I' } },
            { '5', new[] { 'J', 'K', 'L' } },
            { '6', new[] { 'M', 'N', 'O' } },
            { '7', new[] { 'P', 'Q', 'R', 'S' } },
            { '8', new[] { 'T', 'U', 'V' } },
            { '9', new[] { 'W', 'X', 'Y', 'Z' } },
            { '0', new[] { ' ' } }
        };

        public char GetCharacterForKeyPress(char key, int presses)
        {
            if (!KeyMap.TryGetValue(key, out var chars)) return '\0';
            var index = (presses - 1) % chars.Length;
            return chars[index];
        }

        public int GetCharacterCount(char key)
        {
            return KeyMap.TryGetValue(key, out var chars) ? chars.Length : 0;
        }
    }
}
