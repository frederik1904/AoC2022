namespace AOC2022v2;

public class Day5 : SolutioAbstract
{
    protected override string Path { get; } = "Day5Input1.txt";
    public override string Name { get; } = "Day 5";
    public override string SolveOne()
    {
        var input = ReadInput();
        var chunks = new List<Stack<char>?>();
        var index = 0;

        index = SetupChunks(input, chunks, index);

        for (var i = index; i < input.Length; i++)
        {
            var split = input[i].Split(' ');
            var count = int.Parse(split[1]);
            var from = int.Parse(split[3]) - 1;
            var to = int.Parse(split[5]) - 1;

            for (var j = 0; j < count; j++)
            {
                var value = chunks[from]!.Pop();
                chunks[to]!.Push(value);
            }

        }

        return ReturnString(chunks);
    }



    public override string SolveTwo()
    {
        var input = ReadInput();
        var chunks = new List<Stack<char>?>();
        var index = 0;

        index = SetupChunks(input, chunks, index);

        for (var i = index; i < input.Length; i++)
        {
            var split = input[i].Split(' ');
            var count = int.Parse(split[1]);
            var from = int.Parse(split[3]) - 1;
            var to = int.Parse(split[5]) - 1;

            var storage = new List<char>();

            for (var j = 0; j < count; j++)
            {
                storage.Add(chunks[from]!.Pop());
            }

            storage.Reverse();
            
            foreach (var c in storage)
            {
                chunks[to]!.Push(c);
            }

        }
        
        return ReturnString(chunks);
    }
    
    
    private static int SetupChunks(IReadOnlyList<string> input, IList<Stack<char>?> chunks, int index)
    {
        for (var i = 0; i < input[0].ToCharArray().Length; i++)
        {
            chunks.Add(new Stack<char>());
        }

        foreach (var line in input)
        {
            index++;

            var chars = line.ToCharArray();
            if (chars[1] < 'A' && chars[1] != ' ')
            {
                index++;
                break;
            }

            for (var i = 0; i < chars.Length; i += 4)
            {
                var letter = chars[i + 1];
                if (letter != ' ')
                {
                    chunks[i / 4]!.Push(letter);
                }
            }
        }

        for (var i = 0; i < chunks.Count; i++)
        {
            if (chunks[i] == null) continue;
            var rev = new Stack<char>();
            foreach (var c in chunks[i]!)
            {
                rev.Push(c);
            }

            chunks[i] = rev;
        }

        return index;
    }

    private static string ReturnString(List<Stack<char>?> chunks)
    {
        var res = "";
        foreach (var chunk in chunks)
        {
            if (chunk != null && chunk.Count > 0)
            {
                res += chunk.Pop();
            }
        }

        return res;
    }
}