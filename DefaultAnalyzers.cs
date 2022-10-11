internal static class DefaultAnalyzers
{

    public static Lazy<FanOutAnalyzer> FanInAnalyzer { get; } = new Lazy<FanOutAnalyzer>(() => new FanOutAnalyzer());

    public static Lazy<FanInAnalyzer> FanOutAnalyzer { get; } = new Lazy<FanInAnalyzer>(() => new FanInAnalyzer());

    public static Lazy<InstabiliyAnalyzer> InstabilityAnalyzer { get; } = new Lazy<InstabiliyAnalyzer>(() => new InstabiliyAnalyzer());

    public static Lazy<AbstractionAnalyzer> AbstractionAnalyzer { get; } = new Lazy<AbstractionAnalyzer>(() => new AbstractionAnalyzer());

}