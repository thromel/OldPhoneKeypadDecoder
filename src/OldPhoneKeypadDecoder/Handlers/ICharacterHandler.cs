using OldPhoneKeypadDecoder.Models;

namespace OldPhoneKeypadDecoder.Handlers
{
    public interface ICharacterHandler
    {
        void SetNext(ICharacterHandler next);
        void Handle(char ch, DecodeContext context);
    }
}
