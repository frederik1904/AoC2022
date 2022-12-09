namespace AOC2022v2.Inputs;

public class Day6 : SolutioAbstract
{
    protected override string Path { get; } = "Day6Input1.txt";
    public override string Name { get; } = "Day 6";
    public override string SolveOne()
    {
        if (FindEndOfFirstOccurenceOfNUniqueChars(out var s, 4)) return s;
        throw new NotImplementedException();
    }

    private bool FindEndOfFirstOccurenceOfNUniqueChars(out string s, int n)
    {
        var input = ReadInput()[0].ToCharArray();
        for (var i = 0; i < input.Length - n; i++)
        {
            if (input.Skip(i).Take(n).ToHashSet().Count != n) continue;
            
            s = (i + n).ToString();
            return true;
        }

        s = "";
        return false;
    }

    public override string SolveTwo()
    {
        if (FindEndOfFirstOccurenceOfNUniqueChars(out var s, 14)) return s;
        throw new NotImplementedException();
    }
}