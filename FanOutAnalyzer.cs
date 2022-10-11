using Microsoft.CodeAnalysis;

public class FanOutAnalyzer : ProjectAnalyzerBase
{

    const string CSPROJ_EXT = ".csproj";

    public override async Task<IProjectAnalyze> GetAnalyze(ProjectInfo projectInfo, SolutionAnalyzer context)
    {
        var fanIn = new List<ProjectInfo>();
        foreach (var dependency in projectInfo.ProjectRootElement.Items.Where(x => x.Include.EndsWith(CSPROJ_EXT)))
        {
            var dependencyProjectName = dependency.Include.Split("\\").Last().Replace(CSPROJ_EXT, string.Empty);
            var dependencyProject = context.Projects.Single(x => string.Equals(dependencyProjectName, x.Name));
            fanIn.Add(dependencyProject);
        }

        return await Task.FromResult(new FanOutAnalyze(fanIn));
    }

}
