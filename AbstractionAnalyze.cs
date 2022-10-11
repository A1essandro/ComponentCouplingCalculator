using System.Diagnostics;

[DebuggerDisplay("A:{Abstraction}")]
public class AbstractionAnalyze : IProjectAnalyze
{

    public AbstractionAnalyze(IEnumerable<string> concreteTypes, IEnumerable<string> abstractTypes)
    {
        ConcreteTypes = concreteTypes.ToArray();
        AbstractTypes = abstractTypes.ToArray();
    }

    public IReadOnlyCollection<string> ConcreteTypes { get; }

    public IReadOnlyCollection<string> AbstractTypes { get; }

    public IReadOnlyCollection<string> AllTypes => ConcreteTypes.Union(AbstractTypes).ToArray();

    public float Abstraction => ((float)(AbstractTypes.Count)) / (ConcreteTypes.Count + AbstractTypes.Count);

}
