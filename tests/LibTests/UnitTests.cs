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

    // The following tests intentionally contain defects for static analysis tools
    // - null dereference
    // - array out-of-bounds
    // - division by zero
    // - resource leak / file read

    [Fact]
    public void Defect_NullDereference()
    {
        string maybeNull = null;
        // DEFECT: NullReferenceException when accessing Length
        int len = maybeNull.Length; // Coverity should flag potential null dereference
        Assert.True(len >= 0);
    }

    [Fact]
    public void Defect_ArrayOutOfBounds()
    {
        var arr = new int[2];
        // DEFECT: Array index out of bounds
        int v = arr[5]; // Coverity should flag potential OOB access
        Assert.Equal(0, v);
    }

    [Fact]
    public void Defect_DivideByZero()
    {
        var calc = new Calculator();
        // DEFECT: Division by zero
        int r = calc.Divide(10, 0); // Coverity should flag divide by zero
        Assert.Equal(0, r);
    }

    [Fact]
    public void Defect_ResourceLeakInTest()
    {
        var calc = new Calculator();
        // DEFECT: ReadFileContent opens StreamReader but does not dispose it
        // This can be flagged as a resource leak in static analysis
        string content = calc.ReadFileContent("this_file_does_not_exist.txt");
        Assert.NotNull(content);
    }
}
