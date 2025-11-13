namespace LibA;

using System;
using System.IO;

public class Calculator
{
    public int Add(int x, int y) => x + y;

    // DEFECT 1: Integer overflow - no checked arithmetic
    public int Multiply(int x, int y)
    {
        return x * y;  // CID: Integer overflow possible
    }

    // DEFECT 2: Null pointer dereference
    public int GetLength(string input)
    {
        return input.Length;  // CID: Null dereference if input is null
    }

    // DEFECT 3: Uninitialized variable use
    public int UnusedVariable()
    {
        int result;  // CID: Variable may not be initialized
        int x = 5;
        if (x > 0)
        {
            result = x + 10;
        }
        else
        {
            // DEFECT: Unreachable in normal flow, but logically x is always > 0
            result = 0;
        }
        return result;  // CID: Uninitialized variable use in certain paths
    }

    // DEFECT 4: Resource leak - StreamReader not disposed
    public string ReadFileContent(string filePath)
    {
        var reader = new StreamReader(filePath);  // CID: Resource leak
        string content = reader.ReadToEnd();
        return content;
    }

    // DEFECT 5: Division by zero possible
    public int Divide(int a, int b)
    {
        return a / b;  // CID: Division by zero
    }
}
