var analyzer = new SolutionAnalyzer(args[0]);

IProjectAnalyzer[] projectAnalyzers = new[] { new DistanceFromMainSequenceAnalyzer() };
await analyzer.UseAnalyzers(projectAnalyzers);

Console.ReadKey();