using OptimizationProblems.Problems;
using OptimizationProblems.Problems.Problem1;
using OptimizationProblems.Problems.Problem2;

namespace OptimizationProblems
{
    internal class Program
    {
        static void Main()
        {
            IProblem p = new Problem2();
            p.Run();
        }
    }
}
