using System.Diagnostics;

[DebuggerDisplay("FanOut: {FanOut.Count}")]
public class FanOutAnalyze : IProjectAnalyze
{

    public FanOutAnalyze(IReadOnlyCollection<ProjectInfo> fanOut)
    {
        FanOut = fanOut;
    }

    public IReadOnlyCollection<ProjectInfo> FanOut { get; } = Array.Empty<ProjectInfo>();

}