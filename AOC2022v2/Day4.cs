namespace AOC2022v2.Inputs;

public class Day4 : SolutioAbstract
{
    protected override string Path { get; } = "Day4Input1.txt";
    public override string Name { get; } = "Day 4";
    public override string SolveOne()
    {
        return FindOverlaps(
            (elf1, elf2) => (elf1[0] <= elf2[0] && elf1[1] >= elf2[1]) || (elf1[0] >= elf2[0] && elf1[1] <= elf2[1])
            );
    }

    private string FindOverlaps(Func<List<int>, List<int>, bool> overlap)
    {
        var input = ReadInput();
        var res = (from line 
            in input select line.Split(",") 
            into elfs 
            let elf1 = elfs[0]
                .Split("-")
                .Select(int.Parse)
                .ToList() 
            let elf2 = elfs[1]
                .Split("-")
                .Select(int.Parse)
                .ToList() 
            where overlap(elf1, elf2) 
            select elf1).Count();

        return res.ToString();
    }

    public override string SolveTwo()
    {
        return FindOverlaps(
            (elf1, elf2) => elf1[0] <= elf2[1] && elf1[1] >= elf2[0]
        );
    }
}