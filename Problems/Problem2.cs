using Google.OrTools.LinearSolver;
using static Google.OrTools.LinearSolver.Solver;

namespace OptimizationProblems.Problems;

internal class Problem2 : IProblem
{
    public const string Name = "2. Circuits";

    public void Run()
    {
        var solver = new Solver(Name, OptimizationProblemType.SCIP_MIXED_INTEGER_PROGRAMMING);

        Variable typeAVar = solver.MakeIntVar(0, int.MaxValue, "TypeA");
        Variable typeBVar = solver.MakeIntVar(0, int.MaxValue, "TypeB");

        Objective objective = solver.Objective();
        objective.SetCoefficient(typeAVar, 5);
        objective.SetCoefficient(typeBVar, 12);
        objective.SetMaximization();

        Constraint resistorsConstraint = solver.MakeConstraint(0, 200, "Resistors");
        resistorsConstraint.SetCoefficient(typeAVar, 20);
        resistorsConstraint.SetCoefficient(typeBVar, 10);

        Constraint transistorsConstraint = solver.MakeConstraint(0, 120, "Transistors");
        transistorsConstraint.SetCoefficient(typeAVar, 10);
        transistorsConstraint.SetCoefficient(typeBVar, 20);

        Constraint capacitorsConstraint = solver.MakeConstraint(0, 150, "Capacitors");
        capacitorsConstraint.SetCoefficient(typeAVar, 10);
        capacitorsConstraint.SetCoefficient(typeBVar, 30);

        ResultStatus resultStatus = solver.Solve();

        Util.PrintProblemResult(Name, resultStatus, objective, solver.variables());
    }
}
