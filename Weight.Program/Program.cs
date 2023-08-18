using Weight.Program.WeightDatabase.Tables;
using Weight.Program.CSV;
using Weight.Program.WeightDatabase;
using System.Text;

namespace Weight.Program;

public class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Default;
        
        using (var db = new WeightContext())
        {
            db.SeedFromCsv();
            //var controlWeighings = db.ControlWeighings.FirstOrDefault(c => c.ControlWeighingSettingsId != null);
            //var controlWeighingSettings = controlWeighings.ControlWeighingSettings;
            //Console.WriteLine(controlWeighingSettings is null);
            foreach (var x in db.ControlWeighingStatuses)
            {
                Console.WriteLine($"-{x.Name}-");
            }
        }
    }
}