namespace AOC2022v2;

public class Day7 : SolutioAbstract
{
    protected override string Path { get; } = "Day7Input1.txt";
    public override string Name { get; } = "Day 7";
    public override string SolveOne()
    {
        var driveMap = SetupDrive();
        var res = 0;
        foreach (var (_, tuple) in driveMap)
        {
            if (tuple.Value.Item3 <= 100_000)
            {
                res += tuple.Value.Item3;
            }
        }

        return res.ToString();
    }

    public override string SolveTwo()
    {

        const int totalSpace = 70_000_000;
        const int minNeeded = 30_000_000;
        var driveMap = SetupDrive();
        var dirSizes = new List<int>();
        foreach (var (_, tuple) in driveMap)
        {
            dirSizes.Add(tuple.Value.Item3);
        }
        
        dirSizes.Sort();

        var sum = dirSizes.Sum();
        var spaceNeeded =  Math.Abs(totalSpace - dirSizes[^1] - minNeeded);
        return dirSizes.First(dirSize => dirSize >= spaceNeeded).ToString();
    }
    
    
    private Dictionary<string, (HashSet<string>, Dictionary<string, int>, int)?> SetupDrive()
    {
        var input = ReadInput();
        var drive = new Dictionary<string, (HashSet<string>, Dictionary<string, int>, int)?>();
        var pathStack = new Stack<string>();
        pathStack.Push("");
        foreach (var line in input)
        {
            var splitInput = line.Split(" ");
            (HashSet<string>, Dictionary<string, int>, int)? currentPath;
            string? currPath;
            switch (splitInput[0])
            {
                case "$":
                    switch (splitInput[1])
                    {
                        case "cd":
                            var dirName = splitInput[2];
                            switch (dirName)
                            {
                                case "/":
                                    pathStack = new Stack<string>();
                                    pathStack.Push("");
                                    break;
                                case "..":
                                    pathStack.Pop();
                                    break;
                                default:
                                    pathStack.Push(dirName);
                                    break;
                            }

                            break;
                        case "ls":
                            currPath = string.Join('/', pathStack.ToArray());
                            currentPath = drive.GetValueOrDefault(currPath, null);
                            if (currentPath != null) continue;

                            drive[currPath] = (new HashSet<string>(), new Dictionary<string, int>(), 0);
                            break;
                    }

                    break;
                default:
                    currPath = string.Join('/', pathStack.ToArray());
                    currentPath = drive.GetValueOrDefault(currPath, null);

                    switch (splitInput[0])
                    {
                        case "dir":
                            currentPath?.Item1.Add(splitInput[1]);
                            break;
                        default:
                            var name = splitInput[1];
                            var value = int.Parse(splitInput[0]);

                            var valueTuple = currentPath!.Value;
                            
                            if (!valueTuple.Item2.ContainsKey(name))
                            {
                                valueTuple.Item3 += value;
                                valueTuple.Item2.Add(name, value);

                                var copyStack = new Stack<string>(new Stack<string>(pathStack));
                                copyStack.Pop();
                                while (copyStack.Count > 0)
                                {
                                    var recPath = string.Join('/', copyStack.ToArray());
                                    currentPath = drive.GetValueOrDefault(recPath, null) ?? (new HashSet<string>(), new Dictionary<string, int>(), 0);

                                    var tuple = currentPath.Value;
                                    tuple.Item3 += value;
                                    drive[recPath] = tuple;
                                    copyStack.Pop();
                                }
                            }

                            drive[currPath] = valueTuple;
                            
                            break;
                    }

                    break;
            }
        }

        return drive;
    }

}