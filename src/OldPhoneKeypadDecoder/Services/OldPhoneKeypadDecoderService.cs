using System.Linq;
using OldPhoneKeypadDecoder.Interfaces;
using OldPhoneKeypadDecoder.Models;
using OldPhoneKeypadDecoder.Handlers;
using OldPhoneKeypadDecoder.Strategies;

namespace OldPhoneKeypadDecoder.Services
{
    /// <summary>
    /// Implements the old phone keypad decoding service using the Chain of Responsibility pattern.
    /// This service processes input sequences according to the classic mobile phone keypad layout
    /// where multiple presses of the same key cycle through available characters.
    /// </summary>
    /// <remarks>
    /// Key features:
    /// - Handles multi-press character selection (e.g., pressing '2' three times gives 'C')
    /// - Supports special characters through the '1' key
    /// - Implements backspace (*) and confirmation (#) functionality
    /// - Manages spaces through the '0' key
    /// </remarks>
    public class OldPhoneKeypadDecoderService(IKeyLayoutStrategy? layoutStrategy = null) : IPhoneKeypadDecoder
    {
        /// <summary>
        /// The layout strategy used to map key presses to characters.
        /// </summary>
        private readonly IKeyLayoutStrategy _layoutStrategy = layoutStrategy ?? new OldPhoneKeyLayoutStrategy();

        /// <summary>
        /// Decodes the given input string according to the old phone keypad layout.
        /// </summary>
        /// <param name="input">The input string to decode.</param>
        /// <returns>The decoded string.</returns>
        public string Decode(string? input)
        {
            if (input is null)
                return string.Empty;

            var context = new DecodeContext(_layoutStrategy);

            // Build the chain of responsibility
            var chain = BuildHandlerChain();

            // Process each character
            foreach (var ch in input)
            {
                chain?.Handle(ch, context);
            }

            // Ensure any remaining buffered character is processed
            context.FlushBuffer();

            return context.Result.ToString();
        }

        /// <summary>
        /// Builds the chain of responsibility for handling different characters.
        /// </summary>
        /// <returns>The first handler in the chain.</returns>
        private ICharacterHandler? BuildHandlerChain()
        {
            // Create handlers
            var hashHandler = new HashHandler(_layoutStrategy);
            var backspaceHandler = new BackspaceHandler(_layoutStrategy);
            var spaceHandler = new SpaceHandler(_layoutStrategy);
            var digitHandler = new DigitHandler(_layoutStrategy);
            var defaultHandler = new DefaultHandler(_layoutStrategy);

            // Build the chain
            hashHandler.SetNext(backspaceHandler);
            backspaceHandler.SetNext(spaceHandler);
            spaceHandler.SetNext(digitHandler);
            digitHandler.SetNext(defaultHandler);

            return hashHandler;
        }
    }
}
