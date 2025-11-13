using System;
using LibA;
using LibB;

namespace App;

class Program
{
    static void Main(string[] args)
    {
        var calc = new Calculator();
        var sum = calc.Add(7, 8);

        var mult = new Multiplier();
        var combined = mult.MultiplyAdd(3, 4, 5); // 3*4 + 5 = 17

        Console.WriteLine($"Calculator.Add(7,8) = {sum}");
        Console.WriteLine($"Multiplier.MultiplyAdd(3,4,5) = {combined}");
    }
}
