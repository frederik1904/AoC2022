// See https://aka.ms/new,console,template for more information

using System.Diagnostics;
using AOC2022v2;
using AOC2022v2.Inputs;


var solutions = new List<SolutioAbstract>
{
    new Day1(),
    new Day2(),
    new Day3(),
    new Day4(),
    new Day5(),
    new Day6(),
    new Day7(),
    new Day8()
};

var sw = new Stopwatch();
Console.WriteLine(" _____________________________________________________");
Console.WriteLine("|{0,6}|{1,10}|{2,15}|{3,15}{4,4}|", "Day", "Part", "Answer", "Time", "(ns)");

foreach (var question in solutions)
{
    LogInformation(sw, question, "Part 1", question.SolveOne);
    LogInformation(sw, question, "Part 2", question.SolveTwo);
}

void LogInformation(Stopwatch stopwatch, SolutioAbstract question, string part, Func<string> solutionFunction)
{
    try
    {
        stopwatch.Reset();
        stopwatch.Start();
        var resultTwo = solutionFunction();
        stopwatch.Stop();
        var timeTwo = stopwatch.Elapsed.TotalNanoseconds;
        Console.WriteLine("|{0,6}|{1,10}|{2,15}|{3,15}{4,4}|", question.Name, part, resultTwo, timeTwo, "(ns)");
    }
    catch (NotImplementedException e)
    {
        // do nothing
    }
    
}
Console.WriteLine("|_____________________________________________________|");