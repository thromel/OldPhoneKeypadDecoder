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
    ///
    /// Key features:
    /// - Handles multi-press character selection (e.g., pressing '2' three times gives 'C')
    /// - Supports special characters through the '1' key
    /// - Implements backspace (*) and confirmation (#) functionality
    /// - Manages spaces through the '0' key
    /// </summary>
    public class OldPhoneKeypadDecoderService(IKeyLayoutStrategy? layoutStrategy = null) : IPhoneKeypadDecoder
    {
        private readonly IKeyLayoutStrategy _layoutStrategy = layoutStrategy ?? new OldPhoneKeyLayoutStrategy();

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
