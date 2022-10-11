public interface IProjectAnalyzer
{

    Task UseAnalyzerOnProject(ProjectInfo projectInfo, SolutionAnalyzer context);

    Task<IProjectAnalyze> GetAnalyze(ProjectInfo projectInfo, SolutionAnalyzer context);

}
