using Weight.WeightDatabase;

namespace Weight.Program;

public class Program
{
    private static void Main(string[] args)
    {
        //using (ApplicationContext db = new())
        //{
        //    db.Database.EnsureDeleted();
        //    db.Database.EnsureCreated();
        //    User user1 = new User { Name = "Tom", Age = 33 };
        //    User user2 = new User { Name = "Alice", Age = 26 };
        //
        //    db.Users.AddRange(user1, user2);
        //    db.SaveChanges();
        //}

        using (ApplicationContext db = new())
        {
            var users = db.Users.ToList();
            Console.WriteLine("Users list:");
            foreach (var u in users)
            {
                Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
        }
    }
}