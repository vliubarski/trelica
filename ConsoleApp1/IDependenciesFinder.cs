
public interface IDependenciesFinder
{
    Dictionary<string, HashSet<string>> FindAllDistinctDependencies(Dictionary<string, List<string>> inputDependencies);
}