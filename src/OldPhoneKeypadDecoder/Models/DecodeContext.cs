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
    public class DecodeContext
    {
        private readonly IKeyLayoutStrategy _layoutStrategy;

        public DecodeContext(IKeyLayoutStrategy? layoutStrategy)
        {
            _layoutStrategy = layoutStrategy ?? throw new ArgumentNullException(nameof(layoutStrategy));
            Result = new StringBuilder();
        }

        public StringBuilder Result { get; }
        public char ActiveKey { get; set; }
        public int Presses { get; set; }

        public void FlushBuffer()
        {
            if (ActiveKey != '\0' && Presses > 0)
            {
                AppendCharacterFromBuffer();
            }
            ActiveKey = '\0';
            Presses = 0;
        }

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
