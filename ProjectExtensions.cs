using Microsoft.CodeAnalysis;

internal static class ProjectExtensions
{
    public static Project AddDocuments(this Project project, IEnumerable<string> files)
    {
        foreach (string file in files)
        {
            project = project.AddDocument(file, File.ReadAllText(file)).Project;
        }
        return project;
    }

    private static IEnumerable<string> GetAllSourceFiles(string directoryPath)
    {
        var res = Directory.GetFiles(directoryPath, "*.cs", SearchOption.AllDirectories);

        return res;
    }

    public static Project WithAllSourceFiles(this Project project)
    {
        string projectDirectory = Directory.GetParent(project.FilePath).FullName;
        var files = GetAllSourceFiles(projectDirectory);
        var newProject = project.AddDocuments(files);
        return newProject;
    }

}
