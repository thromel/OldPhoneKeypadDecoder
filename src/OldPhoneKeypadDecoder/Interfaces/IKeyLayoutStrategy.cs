namespace OldPhoneKeypadDecoder.Interfaces
{
    /// <summary>
    /// Defines the strategy for mapping keypad presses to characters.
    /// This interface allows for different keyboard layouts to be implemented,
    /// such as T9, multi-tap, or custom layouts.
    /// </summary>
    public interface IKeyLayoutStrategy
    {
        /// <summary>
        /// Maps a key press to its corresponding character based on the number of presses.
        /// </summary>
        /// <param name="key">The key that was pressed (usually '0'-'9').</param>
        /// <param name="presses">The number of times the key was pressed.</param>
        /// <returns>The corresponding character, or '\0' if no mapping exists.</returns>
        char GetCharacterForKeyPress(char key, int presses);

        /// <summary>
        /// Gets the number of characters for a given key.
        /// </summary>
        /// <param name="key">The key to get the character count for.</param>
        /// <returns>The number of characters for the given key.</returns>
        int GetCharacterCount(char key);
    }
}
