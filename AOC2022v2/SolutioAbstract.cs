namespace AOC2022v2;

public abstract class SolutioAbstract
{
    protected abstract string Path { get; set; }
    public abstract string Name { get; set; }
    
    public abstract string SolveOne();
    public abstract string SolveTwo();

    protected string[] ReadInput()
    {
        return System.IO.File.ReadAllLines($"C:/Users/Frede/RiderProjects/AOC2022v2/AOC2022v2/Inputs/{Path}");
    }
    
}