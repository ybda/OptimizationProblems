using Google.OrTools.LinearSolver;
using static Google.OrTools.LinearSolver.Solver;

namespace OptimizationProblems.Problems.Problem2;

internal class Problem2 : IProblem
{
    public void Run()
    {
        var solver = new Solver("Cakes", OptimizationProblemType.SCIP_MIXED_INTEGER_PROGRAMMING);

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

        Util.PrintProblemResult(resultStatus, objective, [typeAVar, typeBVar]);
    }
}
