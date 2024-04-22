namespace ConsoleApp1;

public class IoService : IIoService
{
    public Dictionary<string, List<string>> ReadDependencies(string fileName)
    {
        if (!File.Exists(fileName))
        {
            return new Dictionary<string, List<string>>();
        }

        string[] lines = File.ReadAllLines(fileName);
        var inputDependencies = new Dictionary<string, List<string>>();

        foreach (string line in lines.Where(x => !string.IsNullOrEmpty(x)))
        {
            var items = line.Split(' ');
            List<string> d = items.Skip(1).ToList();
            inputDependencies[items[0]] = d;
        }
        return inputDependencies;
    }

    public void PrintDistinctDependencies(Dictionary<string, HashSet<string>> deps)
    {
        var sorteDeps = deps.OrderBy(kvp => kvp.Key);
        foreach (var dep in sorteDeps)
        {
            var v = dep.Value.ToList();
            v.Sort();
            var strings = string.Join(" ", v);
            Console.WriteLine($"{dep.Key}  {strings}");
        }
    }
}
