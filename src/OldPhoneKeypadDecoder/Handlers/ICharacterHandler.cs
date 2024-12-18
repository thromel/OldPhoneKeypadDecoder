using OldPhoneKeypadDecoder.Models;

namespace OldPhoneKeypadDecoder.Handlers
{
    /// <summary>
    /// Interface for character handlers in the phone keypad decoder chain.
    /// </summary>
    public interface ICharacterHandler
    {
        /// <summary>
        /// Sets the next handler in the chain.
        /// </summary>
        /// <param name="next">The next handler to set.</param>
        void SetNext(ICharacterHandler next);

        /// <summary>
        /// Handles the given character in the decoding context.
        /// </summary>
        /// <param name="ch">The character to handle.</param>
        /// <param name="context">The decoding context.</param>
        void Handle(char ch, DecodeContext context);
    }
}
