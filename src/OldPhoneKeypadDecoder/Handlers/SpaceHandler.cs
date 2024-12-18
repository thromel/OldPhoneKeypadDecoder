using OldPhoneKeypadDecoder.Interfaces;
using OldPhoneKeypadDecoder.Models;

namespace OldPhoneKeypadDecoder.Handlers
{
    public class SpaceHandler(IKeyLayoutStrategy layoutStrategy) : BaseHandler(layoutStrategy)
    {
        public override void Handle(char ch, DecodeContext context)
        {
            switch (ch)
            {
                case '0':
                    context.FlushBuffer();
                    context.Result.Append(' ');
                    break;
                case ' ':
                    context.FlushBuffer();
                    break;
                default:
                    base.Handle(ch, context);
                    break;
            }
        }
    }
}
