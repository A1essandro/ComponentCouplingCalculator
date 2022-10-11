using System.Diagnostics;

[DebuggerDisplay("Distance: {Distance}")]
public class DistanceFromMainSequenceAnalyze : IProjectAnalyze
{
    public DistanceFromMainSequenceAnalyze(AbstractionAnalyze abstraction, InstabilityAnalyze instability)
    {
        Abstraction = abstraction;
        Instability = instability;
    }

    public AbstractionAnalyze Abstraction { get; }

    public InstabilityAnalyze Instability { get; }

    public float Distance => Math.Abs(Abstraction.Abstraction + Instability.Instability - 1);

}
