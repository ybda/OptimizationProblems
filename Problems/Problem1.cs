﻿using Google.OrTools.LinearSolver;
using static Google.OrTools.LinearSolver.Solver;

namespace OptimizationProblems.Problems;

internal class Problem1 : IProblem
{
    public const string Name = "1. Cakes";

    public void Run()
    {
        // Create the linear solver
        var solver = CreateSolver("GLOP") ?? throw new Exception("FAIL");

        // Define the variables
        Variable chocolateCakesVar = solver.MakeNumVar(0, double.PositiveInfinity, "ChocolateCakes");
        Variable vanillaCakesVar = solver.MakeNumVar(0, double.PositiveInfinity, "VanillaCakes");

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

        Util.PrintProblemResult(Name, resultStatus, objective, solver.variables());
    }
}
