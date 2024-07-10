using SMachine;
using Moq;

namespace Tests;

[TestFixture]
public class SymbolManagerTests
{
    [Test]
    public void SymbolManagerGetsCoefficientRight()
    {
        // Arrange
        var sConfig = new SymbolConfig();
        var A = sConfig.Apple;
        var B = sConfig.Banana;
        var P = sConfig.Pineapple;
        var W = sConfig.Wildcard;

        var sampleSymbols = new Symbol[4, 3]
        {
            {B, A, A}, // 0
            {A, A, A}, // 0.4 + 0.4 + 0.4 = 1.2 coefficient
            {A, W, B}, // 0
            {W, A, A}, // 0 + 0.4 + 0.4 = 0.8 coefficient
        };

        var mock = new Mock<ISymbolGenerator>();
        mock.Setup(m => m.Gen()).Returns(sampleSymbols);
        var symbolManager = new SymbolManager(sConfig, mock.Object);


        // Act
        var actual = symbolManager.GetTotalCoefficient();


        // Assert
        var expected = 2M;
        Assert.That(actual, Is.EqualTo(expected));
    }
}
