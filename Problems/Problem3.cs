﻿using static Google.OrTools.LinearSolver.Solver;
using System.Xml.Linq;
using Google.OrTools.LinearSolver;

namespace OptimizationProblems.Problems;

internal class Problem3 : IProblem
{
    public const string Name = "3. Furniture";

    public void Run()
    {
        var solver = CreateSolver("GLOP") ?? throw new Exception("FAIL");

        Variable tableVar = solver.MakeNumVar(0, double.PositiveInfinity, "tableVar");
        Variable cupboardVar = solver.MakeNumVar(0, double.PositiveInfinity, "cupboardVar");

        Objective objective = solver.Objective();
        objective.SetCoefficient(tableVar, 600);
        objective.SetCoefficient(cupboardVar, 1800);
        objective.SetMaximization();

        AddConstraints(solver, tableVar, cupboardVar);

        ResultStatus resultStatus = solver.Solve();

        Util.PrintProblemResult(Name, resultStatus, objective, solver.variables());
    }

    private static void AddConstraints(Solver solver, Variable tableVar, Variable cupboardVar)
    {
        {
            Constraint woodType1Constraint = solver.MakeConstraint(0, 40, "woodType1");
            woodType1Constraint.SetCoefficient(tableVar, 0.2);
            woodType1Constraint.SetCoefficient(cupboardVar, 0.1);
        }

        {
            Constraint woodType2Constraint = solver.MakeConstraint(0, 60, "woodType2");
            woodType2Constraint.SetCoefficient(tableVar, 0.1);
            woodType2Constraint.SetCoefficient(cupboardVar, 0.3);
        }

        {
            Constraint woodType3Constraint = solver.MakeConstraint(0, 321, "woodType3");
            woodType3Constraint.SetCoefficient(tableVar, 1.2);
            woodType3Constraint.SetCoefficient(cupboardVar, 1.5);
        }
    }
}
