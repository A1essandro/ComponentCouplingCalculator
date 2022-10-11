using Microsoft.CodeAnalysis;

public class FanInAnalyzer : ProjectAnalyzerBase
{

    public override async Task<IProjectAnalyze> GetAnalyze(ProjectInfo project, SolutionAnalyzer context)
    {
        var fanOutTasks = context.Projects.Select(async p =>
        {
            await CheckFanInAnalyze(context, p);

            var analyze = p.Analyzes.OfType<FanOutAnalyze>().Last();

            if (analyze.FanOut.Select(x => x.Name).Contains(project.Name))
            {
                return p;
            }
            return null;
        });

        var fanOut = await Task.WhenAll(fanOutTasks);

        return await Task.FromResult(new FanInAnalyze(fanOut.Where(x => x != null).ToArray()));
    }

    private async Task CheckFanInAnalyze(SolutionAnalyzer context, ProjectInfo p)
    {
        if (!p.Analyzes.OfType<FanOutAnalyze>().Any())
        {
            await DefaultAnalyzers.FanInAnalyzer.Value.UseAnalyzerOnProject(p, context);
        }
    }
}
