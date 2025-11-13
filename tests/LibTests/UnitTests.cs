using LibA;
using LibB;
using Xunit;

namespace LibTests;

public class UnitTests
{
    [Fact]
    public void Calculator_AddsCorrectly()
    {
        var calc = new Calculator();
        Assert.Equal(5, calc.Add(2, 3));
    }

    [Fact]
    public void Multiplier_MultiplyAdd_Works()
    {
        var mult = new Multiplier();
        // 2 * 3 + 4 = 10
        Assert.Equal(10, mult.MultiplyAdd(2, 3, 4));
    }
}
