using OldPhoneKeypadDecoder.Models;
using OldPhoneKeypadDecoder.Interfaces;

namespace OldPhoneKeypadDecoder.Handlers
{
    /// <summary>
    /// Base implementation of the character handler chain.
    /// Provides core functionality for the Chain of Responsibility pattern.
    /// </summary>
    /// <remarks>
    /// This abstract class implements the basic chain handling mechanism and
    /// maintains a reference to the next handler in the chain.
    /// </remarks>
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
