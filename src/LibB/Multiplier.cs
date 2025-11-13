using LibA;
using System;
using System.Collections.Generic;

namespace LibB;

public class Multiplier
{
    private readonly Calculator _calc;
    private List<int> _cache;  // DEFECT: Uninitialized field

    public Multiplier()
    {
        _calc = new Calculator();
        // DEFECT: _cache not initialized - will cause null dereference
    }

    public int MultiplyAdd(int a, int b, int addend)
    {
        // a * b + addend (uses Calculator.Add to demonstrate cross-lib usage)
        return _calc.Add(a * b, addend);
    }

    // DEFECT 1: Null pointer dereference on _calc if it were null
    public int SafeMultiplyAdd(int a, int b, int addend)
    {
        return _calc.Add(a * b, addend);  // CID: Potential null dereference
    }

    // DEFECT 2: Null pointer dereference - _cache not initialized
    public void CacheResult(int result)
    {
        _cache.Add(result);  // CID: Null dereference - _cache is never initialized
    }

    // DEFECT 3: Integer overflow in multiplication
    public long ComputeLargeMultiply(int a, int b)
    {
        int product = a * b;  // CID: Integer overflow possible
        return product;
    }

    // DEFECT 4: Array access out of bounds possible
    public int GetCachedResult(int index)
    {
        int[] results = { 1, 2, 3 };
        return results[index];  // CID: Array index out of bounds
    }

    // DEFECT 5: Unused return value
    public void ComputeWithoutUsing()
    {
        _calc.Add(5, 10);  // CID: Unused return value
    }
}
