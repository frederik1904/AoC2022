namespace AOC2022v2;

public class Day8 : SolutioAbstract
{
    protected override string Path { get; } = "Day8Input1.txt";
    public override string Name { get; } = "Day 8";

    public override string SolveOne()
    {
        var input = ReadInput();
        var n = input[0].Length;
        var boolGrid = new List<List<bool>>();
        var grid = new List<List<char>>();

        for (var i = 0; i < input[0].Length; i++)
        {
            boolGrid.Add(new List<bool>());
            grid.Add(new List<char>());
        }

        foreach (var line in input)
        {
            var lineChars = line.ToCharArray();
            for (var i = 0; i < lineChars.Length; i++)
            {
                grid[i].Add(lineChars[i]);
                boolGrid[i].Add(false);
            }
        }

        for (var i = 0; i < n; i++)
        {
            var ltMaxHeight = -1;
            var lbMaxHeight = -1;
            var rtMaxHeight = -1;
            var rbMaxHeight = -1;
            for (var j = 0; j < n; j++)
            {
                var lt = grid[i][j];
                var lb = grid[i][n - j - 1];
                var rt = grid[j][i];
                var rb = grid[n - j - 1][i];
                if (lt > ltMaxHeight)
                {
                    boolGrid[i][j] = true;
                    ltMaxHeight = lt;
                }

                if (lb > lbMaxHeight)
                {
                    boolGrid[i][n - j - 1] = true;
                    lbMaxHeight = lb;
                }


                if (rt > rtMaxHeight)
                {
                    boolGrid[j][i] = true;
                    rtMaxHeight = rt;
                }

                if (rb > rbMaxHeight)
                {
                    boolGrid[n - j - 1][i] = true;
                    rbMaxHeight = rb;
                }
            }
        }

        return boolGrid.SelectMany(bools => bools).Count(b => b).ToString();
    }

    public override string SolveTwo()
    {
        var input = ReadInput();
        var n = input[0].Length;
        var boolGrid = new List<List<bool>>();
        var grid = new List<List<char>>();
        var adjacencyGrid = new List<List<int>>();

        for (var i = 0; i < n; i++)
        {
            boolGrid.Add(new List<bool>());
            grid.Add(new List<char>());

            adjacencyGrid.Add(new List<int>());
            for (var j = 0; j < n; j++)
            {
                adjacencyGrid[i].Add(0);
            }
        }

        foreach (var line in input)
        {
            var lineChars = line.ToCharArray();
            for (var i = 0; i < lineChars.Length; i++)
            {
                grid[i].Add(lineChars[i]);
                boolGrid[i].Add(false);
            }
        }

        for (var i = 0; i < n; i++)
        {
            var ltMaxHeight = -1;
            var lbMaxHeight = -1;
            var rtMaxHeight = -1;
            var rbMaxHeight = -1;
            for (var j = 0; j < n; j++)
            {
                var lt = grid[i][j];
                var lb = grid[i][n - j - 1];
                var rt = grid[j][i];
                var rb = grid[n - j - 1][i];
                if (lt > ltMaxHeight)
                {
                    boolGrid[i][j] = true;
                    ltMaxHeight = lt;
                }

                if (lb > lbMaxHeight)
                {
                    boolGrid[i][n - j - 1] = true;
                    lbMaxHeight = lb;
                }


                if (rt > rtMaxHeight)
                {
                    boolGrid[j][i] = true;
                    rtMaxHeight = rt;
                }

                if (rb > rbMaxHeight)
                {
                    boolGrid[n - j - 1][i] = true;
                    rbMaxHeight = rb;
                }
            }
        }

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                    adjacencyGrid[i][j] = FindVisibleTrees(grid, i, j);
            }
        }

        return adjacencyGrid.Select(bools => bools.Max()).Max().ToString();
    }

    private int FindVisibleTrees(IReadOnlyList<List<char>> grid, int posX, int posY)
    {
        var currHeight = grid[posX][posY];
        var maxLineHeight = -1;
        var result = 1;
        // UP
        var tmpRes = 0;
        for (var i = posX - 1; i >= 0; i--)
        {
            var posHeight = grid[i][posY];
            if (maxLineHeight <= posHeight)
            {
                tmpRes++;
            }
            maxLineHeight = Math.Max(posHeight, maxLineHeight);
            if (maxLineHeight >= currHeight)
            {
                break;
            }
        }

        result *= Math.Max(tmpRes, 1);
        ;
        tmpRes = 0;
        maxLineHeight = -1;
        for (var i = posX + 1; i < grid.Count; i++)
        {
            var posHeight = grid[i][posY];
            if (maxLineHeight <= posHeight)
            {
                tmpRes++;
            }
            maxLineHeight = Math.Max(posHeight, maxLineHeight);
            if (maxLineHeight >= currHeight)
            {
                break;
            }
        }

        result *= Math.Max(tmpRes, 1);
        tmpRes = 0;
        maxLineHeight = -1;
        for (var i = posY - 1; i >= 0; i--)
        {
            var posHeight = grid[posX][i];
            if (maxLineHeight <= posHeight)
            {
                tmpRes++;
            }
            maxLineHeight = Math.Max(posHeight, maxLineHeight);
            if (maxLineHeight >= currHeight)
            {
                break;
            }

        }

        result *= Math.Max(tmpRes, 1);
        tmpRes = 0;
        maxLineHeight = -1;
        for (var i = posY + 1; i < grid.Count; i++)
        {
            var posHeight = grid[posX][i];
            if (maxLineHeight <= posHeight)
            {
                tmpRes++;
            }
            maxLineHeight = Math.Max(posHeight, maxLineHeight);
            if (maxLineHeight >= currHeight)
            {
                break;
            }

        }

        return result * Math.Max(tmpRes, 1);
    }
}