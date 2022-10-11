using System.Diagnostics;
using Microsoft.Build.Construction;

[DebuggerDisplay("{Name}")]
public class ProjectInfo
{

    public ProjectInfo(string name, ProjectRootElement project)
    {
        Name = name;
        ProjectRootElement = project;
    }

    public string Name { get; }

    public ProjectRootElement ProjectRootElement { get; }

    public IList<IProjectAnalyze> Analyzes { get; } = new List<IProjectAnalyze>();

}