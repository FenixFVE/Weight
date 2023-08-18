
using System.ComponentModel.DataAnnotations.Schema;

namespace Weight.Program.WeightDatabase.Tables;

public class BaseTable
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    public int? CreaterId { get; set; } = null;
    public DateTime? AuditDate { get; set; } = null;

    public bool IsDelete { get; set; } = false;
    public DateTime? DeletedDate { get; set; } = null;
    public int? DeletedUser { get; set; } = null;
    
    public void Restore()
    {
        IsDelete = false;
        DeletedDate = null;
        DeletedUser = null;
    }
}
