using OldPhoneKeypadDecoder.Interfaces;
using OldPhoneKeypadDecoder.Models;

namespace OldPhoneKeypadDecoder.Handlers
{
    /// <summary>
    /// Represents the final handler in the chain that processes any unhandled characters.
    /// Acts as a catch-all for characters that weren't processed by other handlers.
    /// </summary>
    /// <remarks>
    /// This handler is typically placed at the end of the chain and ignores any
    /// unprocessed characters, effectively filtering out invalid input.
    /// </remarks>
    public class DefaultHandler : BaseHandler
    {
        public override void Handle(char ch, DecodeContext context)
        {
            // For unexpected characters, we do nothing
            // This is the last in chain, so no base.Handle() call needed.
        }
    }
}
