public class InstabiliyAnalyzer : IProjectAnalyzer
{

    public async Task UseAnalyzerOnProject(ProjectInfo projectInfo, SolutionAnalyzer context)
    {
        projectInfo.Analyzes.Add(await GetAnalyze(projectInfo, context));
    }

    public async Task<IProjectAnalyze> GetAnalyze(ProjectInfo project, SolutionAnalyzer context)
    {
        await CheckFanInAnalyze(context, project);
        await CheckFanOutAnalyze(context, project);

        var fanIn = project.Analyzes.OfType<FanOutAnalyze>().Last();
        var fanOut = project.Analyzes.OfType<FanInAnalyze>().Last();

        return await Task.FromResult(new InstabilityAnalyze(fanIn, fanOut));
    }

    private async Task CheckFanInAnalyze(SolutionAnalyzer context, ProjectInfo p)
    {
        if (!p.Analyzes.OfType<FanOutAnalyze>().Any())
        {
            await DefaultAnalyzers.FanInAnalyzer.Value.UseAnalyzerOnProject(p, context);
        }
    }

    private async Task CheckFanOutAnalyze(SolutionAnalyzer context, ProjectInfo p)
    {
        if (!p.Analyzes.OfType<FanInAnalyze>().Any())
        {
            await DefaultAnalyzers.FanOutAnalyzer.Value.UseAnalyzerOnProject(p, context);
        }
    }
}
