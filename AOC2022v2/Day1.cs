namespace AOC2022v2;

public class Day1 : SolutioAbstract
{
    protected override string Path { get; set; } = "Day1Input1.txt";
    public override string Name { get; set; } = "Day 1";

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

    public override string SolveTwo()
    {
        var calculatedArray = ComputedInput();
        calculatedArray.Sort();
        calculatedArray.Reverse();
        return $"{calculatedArray[0] + calculatedArray[1] + calculatedArray[2]}";
    }
}