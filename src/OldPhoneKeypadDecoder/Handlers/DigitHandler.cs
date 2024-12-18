using System;
using OldPhoneKeypadDecoder.Models;
using OldPhoneKeypadDecoder.Interfaces;

namespace OldPhoneKeypadDecoder.Handlers
{
    public class DigitHandler : BaseHandler
    {
        public DigitHandler(IKeyLayoutStrategy layoutStrategy) : base(layoutStrategy) { }

        public override void Handle(char ch, DecodeContext? context)
        {
            if (context == null) return;

            if (char.IsDigit(ch))
            {
                if (context.ActiveKey != ch)
                {
                    context.FlushBuffer();
                    context.ActiveKey = ch;
                    context.Presses = 1;
                }
                else
                {
                    context.Presses++;

                    var maxChars = LayoutStrategy.GetCharacterCount(ch);
                    if (maxChars > 0)
                    {
                        context.Presses = ((context.Presses - 1) % maxChars) + 1;
                    }
                }
            }
            else
            {
                base.Handle(ch, context);
            }
        }
    }
}
