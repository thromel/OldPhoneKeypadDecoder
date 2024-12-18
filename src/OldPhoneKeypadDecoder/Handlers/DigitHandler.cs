using System;
using OldPhoneKeypadDecoder.Models;
using OldPhoneKeypadDecoder.Interfaces;

namespace OldPhoneKeypadDecoder.Handlers
{
    /// <summary>
    /// Handles numeric input (2-9) in the phone keypad decoder chain.
    /// Processes repeated key presses and manages character cycling.
    /// </summary>
    /// <remarks>
    /// This handler:
    /// - Processes numeric input (2-9)
    /// - Manages repeated key presses for character cycling
    /// - Handles buffer state for multi-press character selection
    /// - Implements wrap-around for excessive key presses
    /// </remarks>
    public class DigitHandler : BaseHandler
    {
        /// <inheritdoc />
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
