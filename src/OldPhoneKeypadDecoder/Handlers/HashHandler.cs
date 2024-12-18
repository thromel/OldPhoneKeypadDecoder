using OldPhoneKeypadDecoder.Interfaces;
using OldPhoneKeypadDecoder.Models;

namespace OldPhoneKeypadDecoder.Handlers
{
    /// <inheritdoc />
    public class HashHandler(IKeyLayoutStrategy layoutStrategy) : BaseHandler(layoutStrategy)
    {
        /// <inheritdoc />
        public override void Handle(char ch, DecodeContext context)
        {
            if (ch == '#')
            {
                // End of input
                context.FlushBuffer();
                // After encountering '#', we typically stop processing.
                // The caller can terminate.
            }
            else
            {
                base.Handle(ch, context);
            }
        }
    }
}
