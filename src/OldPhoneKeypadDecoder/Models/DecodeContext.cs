using System;
using System.Text;
using OldPhoneKeypadDecoder.Interfaces;

namespace OldPhoneKeypadDecoder.Models
{
    /// <summary>
    /// Represents the context for the decoding process, maintaining state
    /// during the character-by-character decoding of phone keypad input.
    /// This class handles buffering of repeated key presses and manages
    /// the current decoding state.
    /// </summary>
    public class DecodeContext(IKeyLayoutStrategy? layoutStrategy)
    {
        /// <summary>
        /// The layout strategy used to map key presses to characters.
        /// </summary>
        private readonly IKeyLayoutStrategy _layoutStrategy = layoutStrategy ?? throw new ArgumentNullException(nameof(layoutStrategy));

        /// <summary>
        /// Gets the result of the decoding process.
        /// </summary>
        public StringBuilder Result { get; } = new();

        /// <summary>
        /// Gets or sets the currently active key being processed.
        /// </summary>
        public char ActiveKey { get; set; }

        /// <summary>
        /// Gets or sets the number of presses for the active key.
        /// </summary>
        public int Presses { get; set; }

        /// <summary>
        /// Flushes the buffer, appending the character represented by the current
        /// active key and its presses to the result, and resets the buffer state.
        /// </summary>
        public void FlushBuffer()
        {
            if (ActiveKey != '\0' && Presses > 0)
            {
                AppendCharacterFromBuffer();
            }
            ActiveKey = '\0';
            Presses = 0;
        }

        /// <summary>
        /// Appends the character represented by the current active key and its presses
        /// to the result.
        /// </summary>
        private void AppendCharacterFromBuffer()
        {
            if (ActiveKey == '\0' || Presses <= 0) return;

            var ch = _layoutStrategy.GetCharacterForKeyPress(ActiveKey, Presses);
            if (ch != '\0')
            {
                Result.Append(ch);
            }
        }
    }
}
