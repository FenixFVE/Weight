using Microsoft.Identity.Client;
using Weight.Program.WeightDatabase;
using Weight.Program.WeightDatabase.Configurations;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program;

public class Program
{
    private static void Main(string[] args)
    {
        AContext.TestAContext();
    }
}