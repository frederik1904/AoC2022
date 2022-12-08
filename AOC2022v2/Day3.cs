namespace AOC2022v2;

public class Day3 : SolutioAbstract
{
    protected override string Path { get; set; } = "Day3Input1.txt";
    public override string Name { get; set; } = "Day 3";

    public override string SolveOne()
    {
        var input = ReadInput();
        var overlaps = new List<char>();

        foreach (var line in input)
        {
            var chars = line.ToCharArray();
            var partOne = chars.Take(chars.Length / 2).ToHashSet();
            var partTwo = chars.Skip(chars.Length / 2).ToHashSet();
            
            partOne.IntersectWith(partTwo);
            overlaps.AddRange(partOne);
        }
        
        return overlaps
            .Sum(GetValue)
            .ToString();
    }

    private static int GetValue(char c)
    {
        if (c >= 'a')
        {
            return (c - Convert.ToInt16('a') + 1);
        }
        return (c - Convert.ToInt16('A') + 27);
    }

    public override string SolveTwo()
    {
        var input = ReadInput();
        var overlaps = new List<char>();

        for (var i = 0; i < input.Length; i += 3)
        {
            var partOne = input[i].ToCharArray().ToHashSet();
            var partTwo = input[i + 1].ToCharArray();
            var partThree = input[i + 2].ToCharArray();
            partOne.IntersectWith(partTwo);
            partOne.IntersectWith(partThree);
            overlaps.AddRange(partOne);
        }
        
        return overlaps
            .Sum(GetValue)
            .ToString();
    }
}