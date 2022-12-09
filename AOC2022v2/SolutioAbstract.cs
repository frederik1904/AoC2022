namespace AOC2022v2;

public abstract class SolutioAbstract
{
    protected abstract string Path { get; set; }
    public abstract string Name { get; set; }
    
    public abstract string SolveOne();
    public abstract string SolveTwo();

    protected string[] ReadInput()
    {
        var projectPath = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent;
        return File.ReadAllLines($"{projectPath}/Inputs/{Path}");
    }
    
}