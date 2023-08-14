using Microsoft.Identity.Client;
using Weight.Program.WeightDatabase;
using Weight.Program.WeightDatabase.Configurations;
using Weight.Program.WeightDatabase.Tables;

namespace Weight.Program;

public class Program
{
    private static void Main(string[] args)
    {
        using (var db = new AContext())
        {
            var a = new A { Name = "One" };
            var b = new A { Name = "Two" };
            db.AddRange(a, b);
            db.SaveChanges();
        }
        
        using (var db = new AContext())
        {
            foreach (var a in db.As)
            {
                Console.WriteLine(a);
            }
        }

        using (var db = new AContext())
        {
            var a = db.As.FirstOrDefault();
            if (a is not null)
            {
                db.As.Remove(a);
                db.SaveChanges();
            }
        }

        using (var db = new AContext())
        {
            foreach (var a in db.As)
            {
                Console.WriteLine(a);
            }
        }
    }
}