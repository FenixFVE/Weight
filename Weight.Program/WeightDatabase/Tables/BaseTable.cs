
namespace Weight.Program.WeightDatabase.Tables;

public class BaseTable
{
    public int Id { get; set; }

    public bool IsDelete { get; set; } = false;
    public DateTime? DeletedDate { get; set; } = null;
    
    public void Restore()
    {
        IsDelete = false;
        DeletedDate = null;
    }
}
