public abstract class ProjectAnalyzerBase : IProjectAnalyzer
{

    public virtual async Task UseAnalyzerOnProject(ProjectInfo projectInfo, SolutionAnalyzer context)
    {
        projectInfo.Analyzes.Add(await GetAnalyze(projectInfo, context));
    }

    public abstract Task<IProjectAnalyze> GetAnalyze(ProjectInfo projectInfo, SolutionAnalyzer context);


}