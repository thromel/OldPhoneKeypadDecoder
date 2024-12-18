using OldPhoneKeypadDecoder.Models;
using OldPhoneKeypadDecoder.Interfaces;

namespace OldPhoneKeypadDecoder.Handlers
{
    public abstract class BaseHandler(IKeyLayoutStrategy layoutStrategy) : ICharacterHandler
    {
        private ICharacterHandler? _nextHandler;
        protected readonly IKeyLayoutStrategy LayoutStrategy = layoutStrategy;

        public virtual void Handle(char ch, DecodeContext context)
        {
            _nextHandler?.Handle(ch, context);
        }

        public void SetNext(ICharacterHandler next)
        {
            _nextHandler = next;
        }
    }
}
