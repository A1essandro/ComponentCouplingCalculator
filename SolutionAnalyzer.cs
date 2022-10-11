using Microsoft.Build.Construction;
using Microsoft.CodeAnalysis;

public class SolutionAnalyzer
{

    const string CSPROJ_EXT = ".csproj";

    public SolutionAnalyzer(string slnPath)
    {
        SolutionFile = SolutionFile.Parse(slnPath);

        DefineProjects();
    }

    public SolutionFile SolutionFile { get; }

    private readonly HashSet<ProjectInfo> _projects = new HashSet<ProjectInfo>();
    public IReadOnlyCollection<ProjectInfo> Projects => _projects.ToArray();

    public Task UseAnalyzers(IEnumerable<IProjectAnalyzer> analyzers)
    {
        var projectsInSolution = SolutionFile.ProjectsInOrder.Where(x => x.AbsolutePath.EndsWith(CSPROJ_EXT));
        var tasks = projectsInSolution.Aggregate(new List<Task>(),
                (list, project) =>
                {
                    var projectInfo = Projects.Single(x => string.Equals(x.Name, project.ProjectName));
                    var tasks = analyzers.Select(a => a.UseAnalyzerOnProject(projectInfo, this));
                    list.Add(Task.WhenAll(tasks));
                    return list;
                });

        return Task.WhenAll(tasks);
    }

    private void DefineProjects()
    {
        foreach (var project in SolutionFile.ProjectsInOrder.Where(x => x.AbsolutePath.EndsWith(CSPROJ_EXT)))
        {
            var rootElement = ProjectRootElement.Open(project.AbsolutePath);
            var projectInfo = new ProjectInfo(project.ProjectName, rootElement);
            _projects.Add(projectInfo);
        }
    }

}
