public class DistanceFromMainSequenceAnalyzer : ProjectAnalyzerBase
{

    public override async Task<IProjectAnalyze> GetAnalyze(ProjectInfo project, SolutionAnalyzer context)
    {
        await CheckAbstractionAnalyze(context, project);
        await CheckInstabilityAnalyze(context, project);

        var abstraction = project.Analyzes.OfType<AbstractionAnalyze>().Last();
        var instability = project.Analyzes.OfType<InstabilityAnalyze>().Last();

        return await Task.FromResult(new DistanceFromMainSequenceAnalyze(abstraction, instability));
    }

    private async Task CheckAbstractionAnalyze(SolutionAnalyzer context, ProjectInfo p)
    {
        if (!p.Analyzes.OfType<AbstractionAnalyze>().Any())
        {
            await DefaultAnalyzers.AbstractionAnalyzer.Value.UseAnalyzerOnProject(p, context);
        }
    }

    private async Task CheckInstabilityAnalyze(SolutionAnalyzer context, ProjectInfo p)
    {
        if (!p.Analyzes.OfType<InstabilityAnalyze>().Any())
        {
            await DefaultAnalyzers.InstabilityAnalyzer.Value.UseAnalyzerOnProject(p, context);
        }
    }

}