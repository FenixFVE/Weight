using Weight.Program.WeightDatabase.Tables;
using Weight.Program.CSV;
using Weight.Program.WeightDatabase;
using System.Text;

namespace Weight.Program;

public class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        using (var db = new WeightContext())
        {
            db.SeedFromCsv();
        }
    }
}