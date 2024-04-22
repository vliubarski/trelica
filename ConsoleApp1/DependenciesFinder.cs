namespace ConsoleApp1;

public class DependenciesFinder : IDependenciesFinder
{
    public Dictionary<string, HashSet<string>> FindAllDistinctDependencies(Dictionary<string, List<string>> inputDependencies)
    {
        var distinctDependencies = new Dictionary<string, HashSet<string>>();
        foreach (var node in inputDependencies.Keys)
        {
            FindNodeDependencies(node, distinctDependencies, inputDependencies);
        }
        return distinctDependencies;
    }

    private HashSet<string> FindNodeDependencies(string node, Dictionary<string, HashSet<string>> distinctDependencies,
        Dictionary<string, List<string>> inputDependencies)
    {
        // node is not listed as having dependency in input file (is a leaf)
        if (!inputDependencies.ContainsKey(node)) 
        {
            return new HashSet<string>();
        }
        
        // this path already processed
        if (distinctDependencies.ContainsKey(node)) 
        {
            return distinctDependencies[node];
        }

        distinctDependencies.Add(node, new HashSet<string>());

        // look for sub dependencies
        foreach (var inputDependency in inputDependencies[node])
        {
            distinctDependencies[node].Add(inputDependency);
            var subDependencies = FindNodeDependencies(inputDependency, distinctDependencies, inputDependencies);
            distinctDependencies[node].UnionWith(subDependencies.Where(x => x != node)); // x != node excludes self referencing for circular dependency
        }
        return distinctDependencies[node];
    }
}