using OldPhoneKeypadDecoder.Interfaces;
using OldPhoneKeypadDecoder.Models;

namespace OldPhoneKeypadDecoder.Handlers
{
    /// <summary>
    /// Handles the decoding of space characters ('0' and ' ') in the old phone keypad input.
    /// </summary>
    /// <remarks>
    /// This handler processes the '0' character as a space and flushes the buffer when a space or '0' is encountered.
    /// </remarks>
    public class SpaceHandler(IKeyLayoutStrategy layoutStrategy) : BaseHandler(layoutStrategy)
    {
        /// <summary>
        /// Handles the specified character during the decoding process.
        /// </summary>
        /// <param name="ch">The character to handle.</param>
        /// <param name="context">The decoding context containing the buffer and result.</param>
        public override void Handle(char ch, DecodeContext context)
        {
            switch (ch)
            {
                case '0':
                    // Flush the buffer and append a space to the result when '0' is encountered.
                    context.FlushBuffer();
                    context.Result.Append(' ');
                    break;
                case ' ':
                    // Flush the buffer when a space is encountered.
                    context.FlushBuffer();
                    break;
                default:
                    // Delegate handling to the base handler for other characters.
                    base.Handle(ch, context);
                    break;
            }
        }
    }
}
