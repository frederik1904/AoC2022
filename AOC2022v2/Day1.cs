using BenchmarkDotNet.Attributes;

namespace AOC2022v2;

public class Day1 : SolutioAbstract
{
    protected override string Path { get; } = "Day1Input1.txt";
    public override string Name { get; } = "Day 1";

    [Benchmark]
    public override string SolveOne()
    {
        return ComputedInput().Max().ToString();
    }

    private List<int> ComputedInput()
    {
        var res = new List<int>();
        
        var curr = 0;
        var input = ReadInput();
        foreach (var line in input)
        {
            if (line == "")
            {
                res.Add(curr);
                curr = 0;
                continue;
            }

            curr += int.Parse(line);
        }

        return res;
    }

    [Benchmark]
    public override string SolveTwo()
    {
        var calculatedArray = ComputedInput();
        calculatedArray.Sort();
        calculatedArray.Reverse();
        return $"{calculatedArray[0] + calculatedArray[1] + calculatedArray[2]}";
    }
}