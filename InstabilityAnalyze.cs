using System.Diagnostics;

[DebuggerDisplay("I:{Instability} (FanIn:{FanIn}, FanOut:{FanOut})")]
public class InstabilityAnalyze : IProjectAnalyze
{

    public InstabilityAnalyze(FanOutAnalyze fanOut, FanInAnalyze fanIn)
    {
        FanOut = fanOut;
        FanIn = fanIn;
    }

    public FanOutAnalyze FanOut { get; }

    public FanInAnalyze FanIn { get; }

    public float Instability => ((float)FanOut.FanOut.Count) / (FanIn.FanIn.Count + FanOut.FanOut.Count);

}
