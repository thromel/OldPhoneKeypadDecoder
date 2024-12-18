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
    public void Decode_ReturnsExpectedOutput(string input, string expected)
    {
        var result = _decoderService.Decode(input);
        Assert.That(result, Is.EqualTo(expected));
    }
}
