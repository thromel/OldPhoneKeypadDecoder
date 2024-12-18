using OldPhoneKeypadDecoder.Interfaces;
using OldPhoneKeypadDecoder.Models;

namespace OldPhoneKeypadDecoder.Handlers
{
    public class BackspaceHandler(IKeyLayoutStrategy layoutStrategy) : BaseHandler(layoutStrategy)
    {
        public override void Handle(char ch, DecodeContext context)
        {
            if (ch == '*')
            {
                if (context.ActiveKey != '\0')
                {
                    // If there's an active buffer, just clear it
                    context.ActiveKey = '\0';
                    context.Presses = 0;
                }
                else if (context.Result.Length > 0)
                {
                    // If no active buffer, remove the last character from result
                    context.Result.Length--;
                }
            }
            else
            {
                base.Handle(ch, context);
            }
        }
    }
}
