using static Google.OrTools.LinearSolver.Solver;
using System.Xml.Linq;
using Google.OrTools.LinearSolver;

namespace OptimizationProblems.Problems;

internal class Problem3 : IProblem
{
    public const string Name = "3. Furniture";

    public void Run()
    {
        var solver = new Solver(Name, OptimizationProblemType.CLP_LINEAR_PROGRAMMING);

        Variable tableVar = solver.MakeIntVar(0, int.MaxValue, "tableVar");
        Variable cupboardVar = solver.MakeIntVar(0, int.MaxValue, "cupboardVar");

        Objective objective = solver.Objective();
        objective.SetCoefficient(tableVar, 600);
        objective.SetCoefficient(cupboardVar, 1800);
        objective.SetMaximization();

        Constraint woodType1Constraint = solver.MakeConstraint(0, 40, "woodType1");
        Constraint woodType2Constraint = solver.MakeConstraint(0, 60, "woodType2");
        Constraint woodType3Constraint = solver.MakeConstraint(0, 321, "woodType3");

        woodType1Constraint.SetCoefficient(tableVar, 0.2);
        woodType2Constraint.SetCoefficient(tableVar, 0.1);
        woodType3Constraint.SetCoefficient(tableVar, 1.2);

        woodType1Constraint.SetCoefficient(cupboardVar, 0.1);
        woodType2Constraint.SetCoefficient(cupboardVar, 0.3);
        woodType3Constraint.SetCoefficient(cupboardVar, 1.5);

        ResultStatus resultStatus = solver.Solve();

        Util.PrintProblemResult(Name, resultStatus, objective, solver.variables());
    }
}
