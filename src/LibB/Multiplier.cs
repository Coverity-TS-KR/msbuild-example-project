using LibA;

namespace LibB;

public class Multiplier
{
    private readonly Calculator _calc;
    public Multiplier()
    {
        _calc = new Calculator();
    }

    public int MultiplyAdd(int a, int b, int addend)
    {
        // a * b + addend (uses Calculator.Add to demonstrate cross-lib usage)
        return _calc.Add(a * b, addend);
    }
}
