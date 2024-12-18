using OldPhoneKeypadDecoder.Interfaces;
using OldPhoneKeypadDecoder.Models;

namespace OldPhoneKeypadDecoder.Handlers
{
    public class SpaceHandler(IKeyLayoutStrategy layoutStrategy) : BaseHandler(layoutStrategy)
    {
        public override void Handle(char ch, DecodeContext context)
        {
            if (ch is ' ' or '0')
            {
                // Flush current character buffer
                context.FlushBuffer();
                // Add space to result for both space and '0' key
                context.Result.Append(' ');
            }
            else
            {
                base.Handle(ch, context);
            }
        }
    }
}
