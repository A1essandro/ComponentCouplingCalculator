using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

public class AbstractionAnalyzer : ProjectAnalyzerBase
{

    private SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

    public override async Task<IProjectAnalyze> GetAnalyze(ProjectInfo projectInfo, SolutionAnalyzer context)
    {
        await _semaphore.WaitAsync();
        try
        {
            var workspace = MSBuildWorkspace.Create();
            var pr = await workspace.OpenProjectAsync(projectInfo.ProjectRootElement.ProjectFileLocation.File);
            pr = pr.WithAllSourceFiles();
            var compilation = await pr.GetCompilationAsync();

            var concreteTypes = new List<string>();
            var abstractTypes = new List<string>();
            foreach (var @class in compilation.GlobalNamespace.GetNamespaceMembers().SelectMany(x => x.GetMembers()))
            {
                var types = @class.GetTypeMembers();
                concreteTypes.AddRange(types.Where(x => !x.IsAbstract).Select(x => x.Name));
                abstractTypes.AddRange(types.Where(x => x.IsAbstract).Select(x => x.Name));
            }

            return new AbstractionAnalyze(concreteTypes, abstractTypes);
        }
        finally
        {
            _semaphore.Release();
        }

    }

}