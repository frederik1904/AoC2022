using System.Diagnostics;

namespace AOC2022v2;

public class Day2 : SolutioAbstract
{
    protected override string Path { get; } = "Day2Input1.txt";
    public override string Name { get; } = "Day 2";
    public override string SolveOne()
    {
        var input = ReadInput();
        int res = 0;
        foreach (var line in input)
        {
            var splitLines = line.Split(" ");
            var a = Convert.ToChar(splitLines[0]);
            var b = splitLines[1] switch
            {
                "X" => 'A',
                "Y" => 'B',
                "Z" => 'C',
                _ => throw new NotImplementedException()
            };

            res = Res(res, b, a);
        }

        return res.ToString();
    }

    public override string SolveTwo()
    {
        var input = ReadInput();
        var res = 0;
        foreach (var line in input)
        {
            var splitLines = line.Split(" ");
            var a = Convert.ToChar(splitLines[0]);
            var b = splitLines[1] switch
            {
                "X" => 'A',
                "Y" => 'B',
                "Z" => 'C',
                _ => throw new NotImplementedException()
            };

            switch (b)
            {
                case 'B':
                    b = a;
                    break;
                case 'A':
                    b = a switch
                    {
                        'A' => 'C',
                        'B' => 'A',
                        'C' => 'B',
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    break;
                default:
                    b = a switch
                    {
                        'A' => 'B',
                        'B' => 'C',
                        'C' => 'A',
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    break;
            }

            res = Res(res, b, a);
        }

        return res.ToString();
    }
    
    private int Res(int res, char b, char a)
    {
        res += b + 1 - Convert.ToInt16('A');

        if (b == 'B' && a == 'A' || b == 'C' && a == 'B' || b == 'A' && a == 'C')
        {
            res += 6;
        }
        else if (b == a)
        {
            res += 3;
        }

        return res;
    }
}