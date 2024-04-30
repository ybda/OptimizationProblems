using Google.OrTools.LinearSolver;
using static Google.OrTools.LinearSolver.Solver;

namespace OptimizationProblems
{
    internal class Program
    {
        static void Main()
        {
            // Create the linear solver
            var solver = new Solver("Cakes", OptimizationProblemType.SCIP_MIXED_INTEGER_PROGRAMMING);

            // Define the variables
            Variable chocolateCakes = solver.MakeIntVar(0, int.MaxValue, "ChocolateCakes");
            Variable vanillaCakes = solver.MakeIntVar(0, int.MaxValue, "VanillaCakes");

            // Define the objective: maximize profit
            Objective objective = solver.Objective();
            objective.SetCoefficient(chocolateCakes, 15);
            objective.SetCoefficient(vanillaCakes, 12);
            objective.SetMaximization();

            Constraint ovenTimeConstraint = solver.MakeConstraint(0, 480, "OvenTime");
            ovenTimeConstraint.SetCoefficient(chocolateCakes, 17);
            ovenTimeConstraint.SetCoefficient(vanillaCakes, 15);

            Constraint flourConstraint = solver.MakeConstraint(0, 300, "Flour");
            flourConstraint.SetCoefficient(chocolateCakes, 10);
            flourConstraint.SetCoefficient(vanillaCakes, 8);

            Constraint sugarConstraint = solver.MakeConstraint(0, 200, "Sugar");
            sugarConstraint.SetCoefficient(chocolateCakes, 8);
            sugarConstraint.SetCoefficient(vanillaCakes, 6);

            ResultStatus resultStatus = solver.Solve();

            if (resultStatus != ResultStatus.OPTIMAL)
            {
                Console.WriteLine($"No optimal solution found: {resultStatus}");
                return;
            }

            Console.WriteLine($"-- Optimal solution --");
            Console.WriteLine($"Chocolate Cakes: {chocolateCakes.SolutionValue()}");
            Console.WriteLine($"Vanilla Cakes: {vanillaCakes.SolutionValue()}");
            Console.WriteLine();
            Console.WriteLine($"Profit: {objective.Value()}");
        }
    }
}
