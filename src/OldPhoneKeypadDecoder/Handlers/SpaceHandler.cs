using OldPhoneKeypadDecoder.Interfaces;
using OldPhoneKeypadDecoder.Models;

namespace OldPhoneKeypadDecoder.Handlers
{
    public class SpaceHandler(IKeyLayoutStrategy layoutStrategy) : BaseHandler(layoutStrategy)
    {
        public override void Handle(char ch, DecodeContext context)
        {
            if (ch == '0')
            {
                context.FlushBuffer();
                context.Result.Append(' ');
            }
            else if (ch == ' ')
            {
                context.FlushBuffer();
            }
            else
            {
                base.Handle(ch, context);
            }
        }
    }
}
