using System.Diagnostics;

[DebuggerDisplay("FanIn: {FanIn.Count}")]
public class FanInAnalyze : IProjectAnalyze
{

    public FanInAnalyze(IReadOnlyCollection<ProjectInfo> fanIn)
    {
        FanIn = fanIn;
    }

    public IReadOnlyCollection<ProjectInfo> FanIn { get; } = Array.Empty<ProjectInfo>();

}
