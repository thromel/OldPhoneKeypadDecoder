using OldPhoneKeypadDecoder.Interfaces;
using OldPhoneKeypadDecoder.Models;

namespace OldPhoneKeypadDecoder.Handlers
{
    /// <inheritdoc />
    public class DefaultHandler(IKeyLayoutStrategy layoutStrategy) : BaseHandler(layoutStrategy)
    {
        public override void Handle(char ch, DecodeContext context)
        {
            // For unexpected characters, we do nothing
            // This is the last in chain, so no base.Handle() call needed.
        }
    }
}
