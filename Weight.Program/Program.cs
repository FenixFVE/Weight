using Weight.Program.WeightDatabase;
using Weight.Program.WeightDatabase.Configurations;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program;

public class Program
{
    private static void Main(string[] args)
    {
        using (var db = new WeightContext())
        {
            //var controlWeighing = new ControllWeighing();

            //db.ControllWeighings.Add(controlWeighing);
            //db.SaveChanges();
        }
    }
}