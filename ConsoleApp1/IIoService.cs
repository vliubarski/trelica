
namespace ConsoleApp1
{
    public interface IIoService
    {
        void PrintDistinctDependencies(Dictionary<string, HashSet<string>> deps);
        Dictionary<string, List<string>> ReadDependencies(string fileName);
    }
}