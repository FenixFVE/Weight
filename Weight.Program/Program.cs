using Weight.Program.WeightDatabase.Tables;
using Weight.Program.CSV;

namespace Weight.Program;

public class Program
{
    private static void Main(string[] args)
    {

        var departments = CsvTableReader.Read<Department>();
        foreach (var  d in departments)
        {
            Console.WriteLine($"Id:{d.Id};Name:{d.Name}");
        }
    }
}