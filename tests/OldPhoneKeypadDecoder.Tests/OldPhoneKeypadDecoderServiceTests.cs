using NUnit.Framework;
using OldPhoneKeypadDecoder.Services;
using OldPhoneKeypadDecoder.Strategies;

namespace OldPhoneKeypadDecoder.Tests;

public class OldPhoneKeypadDecoderServiceTests
{
    private OldPhoneKeypadDecoderService _decoderService;
    private OldPhoneKeyLayoutStrategy? _keyLayoutStrategy;

    [SetUp]
    public void Setup()
    {
        _keyLayoutStrategy = new OldPhoneKeyLayoutStrategy();
        _decoderService = new OldPhoneKeypadDecoderService(_keyLayoutStrategy);
    }

    [Test]
    [TestCase("2#", "A", Description = "Single press")]
    [TestCase("22#", "B", Description = "Double press")]
    [TestCase("222#", "C", Description = "Triple press")]
    [TestCase("7777#", "S", Description = "Multiple presses with wrap-around")]
    [TestCase("9999#", "Z", Description = "Multiple presses with wrap-around")]
    [TestCase("27#", "AP", Description = "Multiple characters")]
    [TestCase("4433 555 555666#", "HELLO", Description = "Multiple words")]
    [TestCase("22 7777#", "BS", Description = "Multiple characters with pause")]
    [TestCase("0#", " ", Description = "Space character")]
    [TestCase("00#", "  ", Description = "Multiple spaces")]
    [TestCase("1#", "&", Description = "Special character")]
    [TestCase("11#", "'", Description = "Special character multiple presses")]
    [TestCase("44 444#", "HI", Description = "Words with pause")]
    [TestCase("44433 555 555666#", "IELLO", Description = "Complex word sequence")]
    [TestCase("#", "", Description = "Only hash")]
    [TestCase("227*#", "B", Description = "Backspace deletes previous character")]
    [TestCase("22#2#", "BA", Description = "Hash confirms current character")]
    [TestCase("227777**#", "", Description = "Multiple backspaces")]
    [TestCase("*22#", "B", Description = "Backspace at start")]
    [TestCase("44433 555 555666**** 6666#", "IM", Description = "Complex sequence with backspaces")]
    [TestCase("33#", "E", Description = "Single character - E")]
    [TestCase("333#", "F", Description = "Single character - F")]
    [TestCase("227*#", "B", Description = "Backspace after multiple characters")]
    [TestCase("4433555 555666#", "HELLO", Description = "Multiple words with space")]
    [TestCase("8 88777444666*664#", "TURING", Description = "Complex word with backspace")]
    [TestCase("", "", Description = "Empty input")]
    [TestCase(" ", "", Description = "Only space")]
    [TestCase("#", "", Description = "Only hash")]
    [TestCase("*", "", Description = "Only backspace")]
    [TestCase("***", "", Description = "Multiple backspaces on empty")]
    [TestCase("2*2*2*#", "", Description = "Alternating input and backspace")]
    [TestCase("999999999#", "W", Description = "Excessive presses")]
    [TestCase("2 2 2#", "AAA", Description = "Multiple spaces between inputs")]
    [TestCase("22 22 22#", "BBB", Description = "Multiple spaces with double press")]
    [TestCase("ABC#", "", Description = "Letters instead of numbers")]
    [TestCase("2a3b4c#", "ADG", Description = "Mixed valid and invalid characters")]
    [TestCase("2@3#", "AD", Description = "Special characters mixed with valid input")]
    [TestCase("12345!@#$%^&*()#", "&ADG", Description = "Complex mixed characters")]
    [TestCase("9999999999999999#", "Z", Description = "Excessive repetition")]
    [TestCase("          #", "", Description = "Multiple spaces only")]
    [TestCase("2 2  2   2    2#", "AAAAA", Description = "Irregular spacing")]
    [TestCase("*//*#", "", Description = "Invalid special characters")]
    public void Decode_ReturnsExpectedOutput(string input, string expected)
    {
        var result = _decoderService.Decode(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Decode_WithNull_ReturnsEmptyString()
    {
        var result = _decoderService.Decode(null);
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Decode_WithInvalidSequence_HandlesGracefully()
    {
        // Testing various invalid sequences
        var invalidInputs = new[]
        {
            "!@#$%^&*()",
            "abcdefghijk",
            ".,;'[]\\",
            "👍🎉🎈"  // Emoji test
        };

        foreach (var input in invalidInputs)
        {
            var result = _decoderService.Decode(input + "#");
            Assert.That(result, Is.Empty);
        }
    }
}
