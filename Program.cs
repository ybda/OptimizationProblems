using OptimizationProblems.Problems;

namespace OptimizationProblems;

public static class Program
{
    private static void Main()
    {
        IList<IProblem> ps =
        [
            new Problem1(),
            new Problem2(),
            new Problem3(),
        ];

        foreach (var p in ps)
        {
            p.Run();
            Console.WriteLine("\n");
        }
    }
}