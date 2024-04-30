using Google.OrTools.LinearSolver;
using static Google.OrTools.LinearSolver.Solver;

namespace OptimizationProblems.Problems.Problem1;

internal class Problem1 : IProblem
{
    public void Run()
    {
        // Create the linear solver
        var solver = new Solver("Cakes", OptimizationProblemType.SCIP_MIXED_INTEGER_PROGRAMMING);

        // Define the variables
        Variable chocolateCakesVar = solver.MakeIntVar(0, int.MaxValue, "ChocolateCakes");
        Variable vanillaCakesVar = solver.MakeIntVar(0, int.MaxValue, "VanillaCakes");

        // Define the objective: maximize profit
        Objective objective = solver.Objective();
        objective.SetCoefficient(chocolateCakesVar, 15);
        objective.SetCoefficient(vanillaCakesVar, 12);
        objective.SetMaximization();

        Constraint ovenTimeConstraint = solver.MakeConstraint(0, 480, "OvenTime");
        ovenTimeConstraint.SetCoefficient(chocolateCakesVar, 17);
        ovenTimeConstraint.SetCoefficient(vanillaCakesVar, 15);

        Constraint flourConstraint = solver.MakeConstraint(0, 300, "Flour");
        flourConstraint.SetCoefficient(chocolateCakesVar, 10);
        flourConstraint.SetCoefficient(vanillaCakesVar, 8);

        Constraint sugarConstraint = solver.MakeConstraint(0, 200, "Sugar");
        sugarConstraint.SetCoefficient(chocolateCakesVar, 8);
        sugarConstraint.SetCoefficient(vanillaCakesVar, 6);

        ResultStatus resultStatus = solver.Solve();

        Util.PrintProblemResult(resultStatus, objective, [chocolateCakesVar, vanillaCakesVar]);
    }
}
