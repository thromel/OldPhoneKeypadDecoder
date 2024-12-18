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
    [TestCase("2", "A", Description = "Single press")]
    [TestCase("22", "B", Description = "Double press")]
    [TestCase("222", "C", Description = "Triple press")]
    [TestCase("7777", "S", Description = "Multiple presses with wrap-around")]
    [TestCase("9999", "Z", Description = "Multiple presses with wrap-around")]
    [TestCase("27", "AP", Description = "Multiple characters")]
    [TestCase("4433555 555666", "HELLO", Description = "Multiple words")]
    [TestCase("227777", "BS", Description = "Multiple characters with wrap-around")]
    [TestCase("0", " ", Description = "Space character")]
    [TestCase("00", " ", Description = "Multiple space presses")]
    [TestCase("1", "&", Description = "Special character")]
    [TestCase("11", "'", Description = "Special character multiple presses")]
    [TestCase("44 444", "H I", Description = "Words with space")]
    [TestCase("44433555 555666", "HELLO", Description = "Complex word sequence")]
    [TestCase("", "", Description = "Empty input")]
    [TestCase(" ", "", Description = "Whitespace input")]
    public void Decode_ValidInputs_ReturnsExpectedOutput(string input, string expected)
    {
        var result = _decoderService.Decode(input);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase("A")]
    [TestCase("abc")]
    [TestCase("12a")]
    public void Decode_InvalidCharacters_ThrowsArgumentException(string input)
    {
        Assert.Throws<ArgumentException>(() => _decoderService.Decode(input));
    }

    [Test]
    [TestCase("227*", "A", Description = "Backspace deletes previous character")]
    [TestCase("22#2", "BA", Description = "Hash confirms current character")]
    [TestCase("227777**", "", Description = "Multiple backspaces")]
    [TestCase("*22", "B", Description = "Backspace at start")]
    [TestCase("44433555 555666**** 6666", "HELL O", Description = "Complex sequence with backspaces")]
    public void Decode_SpecialOperations_HandlesCorrectly(string input, string expected)
    {
        var result = _decoderService.Decode(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}
