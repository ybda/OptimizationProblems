using Google.OrTools.LinearSolver;
using static Google.OrTools.LinearSolver.Solver;
using System.Security.AccessControl;

namespace OptimizationProblems;

internal static class Util
{
    public static string VarNameWithSolutionValue(Variable variable)
    {
        return $"{variable.Name()}: {variable.SolutionValue()}";
    }

    public static string VarNamesWithSolutionValues(IEnumerable<Variable> vars)
    {
        return "[" + string.Join(", ", vars.Select(v => "(" + VarNameWithSolutionValue(v) + ")")) + "]";
    }

    public static void PrintVarNameWithSolutionValue(Variable variable)
    {
        Console.WriteLine(VarNameWithSolutionValue(variable));
    }

    public static void PrintVarNamesWithSolutionValues(IEnumerable<Variable> vars)
    {
        Console.WriteLine(VarNamesWithSolutionValues(vars));
    }

    public static void PrintProblemResult(string problemName, ResultStatus resultStatus, Objective objective, IEnumerable<Variable> vars)
    {
        Console.WriteLine($"# Optimal solution '{problemName}'");

        if (resultStatus != ResultStatus.OPTIMAL)
        {
            Console.WriteLine($"No optimal solution found: {resultStatus}");
            return;
        }

        PrintVarNamesWithSolutionValues(vars);
        Console.WriteLine();
        Console.WriteLine($"Profit: {objective.Value()}");
    }
}
